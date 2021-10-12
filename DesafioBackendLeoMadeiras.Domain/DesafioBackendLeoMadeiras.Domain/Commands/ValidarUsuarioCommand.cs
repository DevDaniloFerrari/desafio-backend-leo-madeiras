using Flunt.Notifications;
using Flunt.Validations;
using MediatR;

namespace DesafioBackendLeoMadeiras.Domain.Commands
{
    public class ValidarUsuarioCommand : Notifiable, IValidatable, IRequest<Response>
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                           .Requires()
                           .IsEmail(Email, "Email", "Email inválido")
                           .IsNotNullOrEmpty(Senha, "Senha", "A senha não pode ser vazia"));
        }
    }
}
