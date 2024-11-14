using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PinkPlate.API.Extensions;
using PinkPlate.API.Interfaces;
using PinkPlate.Application.Notificacoes;
using PinkPlate.Application.Notificacoes.Interfaces;

namespace PinkPlate.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;
        private readonly IUser AppUser;

        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        protected MainController(INotificador notificador, IUser appUser)
        {
            _notificador = notificador;
            AppUser = appUser;

            if (AppUser.IsAuthenticated())
            {
                UsuarioId = AppUser.GetUserId();
                UsuarioAutenticado = true;
            }
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
                return Ok(Result.Ok(result));

            return BadRequest(Result
                              .Fail(_notificador
                                .ObterNotificacoes()
                                .Select(n => n.Mensagem)));
        }

        protected ActionResult CustomUnauthorizedResponse()
        {
            return Unauthorized(Result.Fail("User not logged in", 401));
        }

        protected ActionResult CustomFileResponse(byte[] fileBytes, string contentType, string fileName)
        {
            if (OperacaoValida())
                return File(fileBytes, contentType, fileName);

            return BadRequest(Result
                              .Fail(_notificador
                                .ObterNotificacoes()
                                .Select(n => n.Mensagem)));
        }

        protected ActionResult SendBadRequest(string message)
        {
            return BadRequest(Result
                              .Fail(message));
        }

        protected ActionResult SendInternalErrorRequest(string message)
        {
            return StatusCode(500, (Result
                              .Fail(message, 500)));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);

            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values
                .SelectMany(obj => obj.Errors);

            foreach (var erro in erros)
            {
                var errorMessage = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;

                NotificarErro(errorMessage);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
