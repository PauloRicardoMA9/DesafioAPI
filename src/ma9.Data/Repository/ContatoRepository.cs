using ma9.Business.Interfaces;
using ma9.Business.Models;
using ma9.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ma9.Data.Repository
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(ModelsContext context) : base(context)
        {
        }

        public async Task<Contato> ObterContatoPorCliente(Guid clienteId)
        {
            return await Database.Contatos.AsNoTracking()
                .FirstOrDefaultAsync(contato => contato.ClienteId == clienteId);
        }
    }
}
