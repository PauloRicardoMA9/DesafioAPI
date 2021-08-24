using System.Collections.Generic;
using ma9.Business.Notificacoes;

namespace ma9.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void AdicionarNotificacao(Notificacao notificacao);
    }
}