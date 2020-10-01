using AtechTestBackend.Domain.Models;
using AtechTestBackend.Domain.ViewModels;
using AtechTestBackend.infrastructure.Data.Repository;
using AtechTestBackend.infrastructure.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtechTestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IMapper _mapper;

        public PessoaController(IMapper mapper)
        {
            this._mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromServices] PessoaService _pessoaService)
        {
            IEnumerable<Pessoa> pessoas = await _pessoaService.GetAll();
            return Ok(pessoas);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] PessoaService _pessoaService, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            PaginatedList<Pessoa> pessoas = await _pessoaService.GetPessoas(pageIndex, pageSize);
            List<PessoaViewModel> pessoasVM = _mapper.Map<List<PessoaViewModel>>(pessoas);
            return Ok(pessoasVM);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromServices] PessoaService _pessoaService, [FromBody]Pessoa pessoaPayload)
        {
            if (pessoaPayload.EstadoCivil != "Casado(a)" && pessoaPayload.EstadoCivil != "Solteiro(a)" && pessoaPayload.EstadoCivil != "Viuvo(a)")
            {
                return BadRequest(new { message = "Estado civil deve ser (Casado(a), Solteiro(a), Viuvo(o))" });
            }

            if (pessoaPayload.EstadoCivil == "Casado(a)" && pessoaPayload.NomeParceiro.Trim() == string.Empty)
            {
                return BadRequest(new { message = "Informe o nome do Parceiro" });
            }

            _pessoaService.Insert(pessoaPayload);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromServices] PessoaService _pessoaService, [FromBody]Pessoa pessoaPayload)
        {
            _pessoaService.Update(pessoaPayload);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromServices] PessoaService _pessoaService, int id)
        {
            bool result = await _pessoaService.Remove(id);
            return Ok();
        }
    }
}