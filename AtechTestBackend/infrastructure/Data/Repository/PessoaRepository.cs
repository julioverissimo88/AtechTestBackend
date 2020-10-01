using AtechTestBackend.Domain.Models;
using AtechTestBackend.infrastructure.Data.Context;
using AtechTestBackend.infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AtechTestBackend.infrastructure.Data.Repository
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        private readonly ContextApp _context;

        public PessoaRepository(ContextApp Context) : base(Context)
        {
            this._context = Context;
        }

        public async Task<PaginatedList<Pessoa>> GetPaginatedItens(int pageIndex, int pageSize)
        {
            return await PaginatedList<Pessoa>.ListPaginatedAsync(this._context.Pessoas.AsNoTracking(), pageIndex, pageSize);
        }
    }
}
