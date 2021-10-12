using DesafioBackendLeoMadeiras.Domain.Commands;
using DesafioBackendLeoMadeiras.Domain.Handlers;
using DesafioBackendLeoMadeiras.Domain.Repositories;
using DesafioBackendLeoMadeiras.Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DesafioBackendLeoMadeiras.Tests.Handlers
{
    public class ValidarSenhaCommandHandlerTest
    {
        private readonly ValidarSenhaCommandHandler _handler;

        public ValidarSenhaCommandHandlerTest()
        {
            _handler = new ValidarSenhaCommandHandler();
        }

        [Fact]
        public void ValidarSenhaCommand_QuandoCommandForInvalido_DeveRetornarErro()
        {
            var command = new ValidarSenhaCommand { Senha = "" };

            var result = _handler.Handle(command, It.IsAny<CancellationToken>()).Result;

            Assert.Equal("Erro", result.Mensagem);
        }

        [Fact]
        public void ValidarSenhaCommand_QuandoSenhaForInvalida_DeveRetornarFalso()
        {
            var command = new ValidarSenhaCommand { Senha = "yv1NVfWXWOTYHI" };

            var result = _handler.Handle(command, It.IsAny<CancellationToken>()).Result;

            Assert.False((bool)result.Dado);
        }

        [Fact]
        public void ValidarSenhaCommand_QuandoSenhaForValida_DeveRetornarVerdadeiro()
        {
            var command = new ValidarSenhaCommand { Senha = "yv1NV3afZgT!fWXWOTYHI" };

            var result = _handler.Handle(command, It.IsAny<CancellationToken>()).Result;

            Assert.True((bool)result.Dado);
        }
    }
}
