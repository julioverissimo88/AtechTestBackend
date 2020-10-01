using AtechTestBackend.Domain.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtechTestBackend.Domain.Models
{
    [AutoMap(typeof(PessoaViewModel), ReverseMap = true)]
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string EstadoCivil { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NomeParceiro { get; set; }
        public string DataNascimentoParceiro { get; set; }
    }
}
