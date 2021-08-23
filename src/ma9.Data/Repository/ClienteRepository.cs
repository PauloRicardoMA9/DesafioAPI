using ma9.Business.Interfaces;
using ma9.Business.Models;
using ma9.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ma9.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ModelsContext context) : base(context)
        {
        }

        public async Task<Cliente> ObterClienteComContato(Guid id)
        {
            return await Database.Clientes.AsNoTracking().
                Include(cliente => cliente.Contato).
                FirstOrDefaultAsync(cliente => cliente.Id == id);
        }
    }
}
