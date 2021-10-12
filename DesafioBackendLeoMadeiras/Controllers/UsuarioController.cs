using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioBackendLeoMadeiras.Controllers
{
    [Route("api/usuarios")]
    [Authorize]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("autenticacao")]
        [AllowAnonymous]
        public async Task<IActionResult> ValidarUsuario([FromBody] ValidateUserCommand command, [FromServices] IMediator mediator)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPost]
        [Route("seguranca")]
        public async Task<IActionResult> ValidarSenha([FromBody] ValidatePasswordCommand command, [FromServices] IMediator mediator)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet]
        [Route("senhaAleatoria")]
        public IActionResult GerarSenha([FromServices] IUserService userService)
        {
            return Ok(userService.GeneratePassword());
        }

    }
}
