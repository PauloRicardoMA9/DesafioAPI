using System.Linq;
using ma9.Business.Interfaces;
using ma9.Business.Notificacoes;
using Microsoft.AspNetCore.Mvc;

namespace ma9.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        protected MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.AdicionarNotificacao(new Notificacao(mensagem));
        }

        protected ActionResult ReturnBadRequest()
        {
            return BadRequest(new
            {
                errors = _notificador.ObterNotificacoes().Select(notificacao => notificacao.Mensagem)
            });
        }

        protected ActionResult ReturnNotFound()
        {
            return NotFound(new
            {
                errors = _notificador.ObterNotificacoes().Select(notificacao => notificacao.Mensagem)
            });
        }
    }
}
