using ma9.Business.Models;
using System;
using System.Threading.Tasks;

namespace ma9.Business.Interfaces
{
    public interface IContatoRepository : IRepository<Contato>
    {
        Task<Contato> ObterContatoPorCliente(Guid clienteId);
    }
}
