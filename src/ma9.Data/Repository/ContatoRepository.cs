using ma9.Business.Interfaces;
using ma9.Business.Models;
using ma9.Data.Context;

namespace ma9.Data.Repository
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(ModelsContext context) : base(context)
        {
        }
    }
}
