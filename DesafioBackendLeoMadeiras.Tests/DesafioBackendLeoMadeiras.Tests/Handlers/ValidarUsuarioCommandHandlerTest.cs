using DesafioBackendLeoMadeiras.Domain.Commands;
using DesafioBackendLeoMadeiras.Domain.DTOs;
using DesafioBackendLeoMadeiras.Domain.Entities;
using DesafioBackendLeoMadeiras.Domain.Handlers;
using DesafioBackendLeoMadeiras.Domain.Repositories;
using DesafioBackendLeoMadeiras.Domain.Services;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace DesafioBackendLeoMadeiras.Tests.Handlers
{
    public class ValidarUsuarioCommandHandlerTest
    {
        private readonly ValidarUsuarioCommandHandler _handler;
        private readonly Mock<ITokenService> _tokenService;
        private readonly Mock<IUsuarioRepository> _usuarioRepository;

        public ValidarUsuarioCommandHandlerTest()
        {
            _tokenService = new Mock<ITokenService>();
            _usuarioRepository = new Mock<IUsuarioRepository>();
            _handler = new ValidarUsuarioCommandHandler(_usuarioRepository.Object, _tokenService.Object);
        }

        [Fact]
        public void ValidarUsuarioCommand_QuandoCommandForInvalido_DeveRetornarErro()
        {
            var command = new ValidarUsuarioCommand { Email = "usuario.com", Senha = "123456" };

            var result = _handler.Handle(command, It.IsAny<CancellationToken>()).Result;

            Assert.Equal("Erro", result.Mensagem);
        }


        [Fact]
        public void ValidarUsuarioCommand_QuandoUsuarioNaoRegistrado_DeveRetornarErro()
        {
            var command = new ValidarUsuarioCommand { Email = "usuario@email.com", Senha = "123456" };

            _usuarioRepository.Setup(x => x.ObterUsuario(It.IsAny<string>()));

            var result = _handler.Handle(command, It.IsAny<CancellationToken>()).Result;

            Assert.Equal("Email ou senha inválidos", result.Mensagem);

            _usuarioRepository.Verify(x => x.ObterUsuario(It.IsAny<string>()), Times.Once);
        }


        [Fact]
        public void ValidarUsuarioCommand_QuandoSenhaNaoForAMesma_DeveRetornarErro()
        {
            var command = new ValidarUsuarioCommand { Email = "usuario@email.com", Senha = "123456" };
            var user = new Usuario("nome", command.Email, "12345533367");

            _usuarioRepository.Setup(x => x.ObterUsuario(It.IsAny<string>())).Returns(user);

            var result = _handler.Handle(command, It.IsAny<CancellationToken>()).Result;

            Assert.Equal("Email ou senha inválidos", result.Mensagem);

            _usuarioRepository.Verify(x => x.ObterUsuario(It.IsAny<string>()), Times.Once);
        }


        [Fact]
        public void ValidarUsuarioCommandCommand_DeveRetornarSucess()
        {
            var command = new ValidarUsuarioCommand { Email = "usuario@email.com", Senha = "123456" };
            var user = new Usuario("nome", command.Email, "123456");
            var token = new TokenDTO("EFNIU3r//TokenTest", DateTime.Now.AddMinutes(5));

            _usuarioRepository.Setup(x => x.ObterUsuario(It.IsAny<string>())).Returns(user);
            _tokenService.Setup(x => x.GerarToken(It.IsAny<Usuario>())).Returns(token);
            
            var result = _handler.Handle(command, It.IsAny<CancellationToken>()).Result;

            Assert.NotNull(result);
            Assert.NotEmpty(result.Mensagem);
            Assert.NotNull(result.Dado);
            Assert.IsType<UsuarioDTO>(result.Dado);

            _usuarioRepository.Verify(x => x.ObterUsuario(It.IsAny<string>()), Times.Once);
            _tokenService.Verify(x => x.GerarToken(It.IsAny<Usuario>()), Times.Once);
        }
    }
}
