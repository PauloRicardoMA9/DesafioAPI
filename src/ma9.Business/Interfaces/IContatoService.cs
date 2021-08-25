using ma9.Business.Models;
using System;
using System.Threading.Tasks;

namespace ma9.Business.Interfaces
{
    public interface IContatoService : IDisposable
    {
        Task<bool> Adicionar(Contato contato);
        Task<bool> Atualizar(Guid id, Contato contatoAtualizado);
        Task<bool> RemoverPorId(Guid id);
    }
}
