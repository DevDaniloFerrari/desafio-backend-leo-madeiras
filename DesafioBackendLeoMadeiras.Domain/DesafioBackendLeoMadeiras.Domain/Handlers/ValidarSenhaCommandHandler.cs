using DesafioBackendLeoMadeiras.Domain.Commands;
using DesafioBackendLeoMadeiras.Domain.Helpers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioBackendLeoMadeiras.Domain.Handlers
{
    public class ValidarSenhaCommandHandler : IRequestHandler<ValidarSenhaCommand, Response>
    {
        public async Task<Response> Handle(ValidarSenhaCommand command, CancellationToken cancellationToken)
        {
            command.Validate();
            if (command.Invalid)
                return new Response(command.Notifications);

            var senhaEhValida = SenhaHelper.ValidarSenha(command.Senha);

            return new Response("Senha verificada com sucesso", senhaEhValida);
        }
    }
}
