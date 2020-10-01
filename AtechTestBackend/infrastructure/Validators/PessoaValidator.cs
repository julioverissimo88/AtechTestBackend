using AtechTestBackend.Domain.Models;
using FluentValidation;

namespace AtechTestBackend.infrastructure.Validators
{
    public class PessoaValidator : AbstractValidator<Pessoa>
    {
        public PessoaValidator()
        {
            RuleFor(x => x.Nome).NotNull().WithMessage("Campo Nome é obrigatório.");
            RuleFor(x => x.Nome).MinimumLength(5).WithMessage("Campo Nome deve possuir no mínimo 5 caracteres.");
            RuleFor(x => x.DataNascimento).NotNull().WithMessage("Campo Data Nascimento é obrigatório.");
            RuleFor(x => x.EstadoCivil).NotNull().WithMessage("Campo Estado Civil é obrigatório.");
        }
    }
}
