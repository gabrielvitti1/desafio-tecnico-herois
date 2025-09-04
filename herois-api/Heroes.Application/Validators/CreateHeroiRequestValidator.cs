using FluentValidation;
using Heroes.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Application.Validators
{
    public class CreateHeroiRequestValidator : AbstractValidator<CreateHeroiRequest>
    {
        public CreateHeroiRequestValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório")
                .Length(1, 120).WithMessage("O nome deve ter entre 1 e 120 caracteres");

            RuleFor(x => x.NomeHeroi)
                .NotEmpty().WithMessage("O nome do herói é obrigatório")
                .Length(1, 120).WithMessage("O nome deve ter entre 1 e 120 caracteres");

            RuleFor(x => x.Altura)
                .GreaterThan(0).WithMessage("A altura deve ser maior que 0");

            RuleFor(x => x.Peso)
                .GreaterThan(0).WithMessage("O peso deve ser maior que 0");

            RuleFor(x => x.DataNascimento)
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser no passado");

            RuleFor(x => x.SuperpoderesIds)
                .NotNull().WithMessage("A lista de superpoderes não pode ser nula")
                .NotEmpty().WithMessage("A lista de superpoderes não pode estar vazia");
        }
    }
}
