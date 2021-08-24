using ma9.Business.Models;
using System;
using System.Threading.Tasks;

namespace ma9.Business.Interfaces
{
    public interface IClienteService : IDisposable
    {
        Task<bool> Adicionar(Cliente cliente);
        Task<bool> Atualizar(Guid id, Cliente clienteAtualizado);
        Task<bool> RemoverPorId(Guid id);
    }
}
