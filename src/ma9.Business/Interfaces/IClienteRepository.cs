using ma9.Business.Models;
using System;
using System.Threading.Tasks;

namespace ma9.Business.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterCliente(Guid id);
        Task<Cliente> ObterClienteComContato(Guid id);
    }
}
