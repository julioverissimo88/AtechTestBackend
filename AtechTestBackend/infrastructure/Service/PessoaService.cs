using AtechTestBackend.Domain.Models;
using AtechTestBackend.infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtechTestBackend.infrastructure.Service
{
    public class PessoaService
    {
        private PessoaRepository _pessoaRepository { get; set; }

        public PessoaService(PessoaRepository pessoarepository)
        {
            this._pessoaRepository = pessoarepository;
        }

        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            return  _pessoaRepository.GetAll();
        }

        public async Task<PaginatedList<Pessoa>> GetPessoas(int pageIndex, int pageSize)
        {
            return await _pessoaRepository.GetPaginatedItens(pageIndex, pageSize);
        }

        public async Task<bool> Remove(int id)
        {
            return this._pessoaRepository.Remove(id);
        }

        public virtual void Insert(Pessoa obj)
        {
            try
            {
                this._pessoaRepository.Add(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Update(Pessoa obj)
        {
            try
            {
                this._pessoaRepository.Update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
