using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AtechTestBackend.Domain.ViewModels
{
    public class PessoaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string EstadoCivil { get; set; }

        [JsonIgnore]
        public DateTime DataNascimento { get; set; }
        public string DtNascimento { get { return this.DataNascimento.ToString("dd/MM/yyyy"); } }

        public string NomeParceiro { get; set; }

        public string DtNascimentoParceiro { get { return this.DataNascimento.ToString("dd/MM/yyyy"); } }
        [JsonIgnore]
        public string DataNascimentoParceiro { get; set; }
    }
}
