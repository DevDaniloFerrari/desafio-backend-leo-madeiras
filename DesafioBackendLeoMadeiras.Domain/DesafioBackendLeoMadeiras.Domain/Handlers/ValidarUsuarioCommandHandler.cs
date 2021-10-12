using DesafioBackendLeoMadeiras.Domain.Commands;
using DesafioBackendLeoMadeiras.Domain.DTOs;
using DesafioBackendLeoMadeiras.Domain.Helpers;
using DesafioBackendLeoMadeiras.Domain.Repositories;
using DesafioBackendLeoMadeiras.Domain.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioBackendLeoMadeiras.Domain.Handlers
{
    public class ValidarUsuarioCommandHandler : IRequestHandler<ValidarUsuarioCommand, Response>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;

        public ValidarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        public async Task<Response> Handle(ValidarUsuarioCommand command, CancellationToken cancellationToken)
        {
            command.Validate();
            if (command.Invalid)
                return new Response(command.Notifications);

            var usuario = _usuarioRepository.ObterUsuario(command.Email);
            if (usuario == null || !SenhaHelper.VerificarSenha(command.Senha, usuario.Senha))
                return new Response("Email ou senha inválidos");

            var token = _tokenService.GerarToken(usuario);
            var usuarioDTO = new UsuarioDTO(usuario.Email, true, token.Token, token.ExpiraEm);

            return new Response("Token gerado com sucesso", usuarioDTO);
        }
    }
}
