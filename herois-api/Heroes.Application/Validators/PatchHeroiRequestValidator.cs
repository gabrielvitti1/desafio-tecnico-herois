using FluentValidation;
using Heroes.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Application.Validators
{
    public class PatchHeroiRequestValidator : AbstractValidator<PatchHeroiRequest>
    {
        public PatchHeroiRequestValidator()
        {
            RuleFor(x => x.Nome)
                .Length(1, 120)
                .When(x => !string.IsNullOrWhiteSpace(x.Nome))
                .WithMessage("O nome deve ter entre 1 e 120 caracteres");

            RuleFor(x => x.NomeHeroi)
                .Length(1, 120)
                .When(x => !string.IsNullOrWhiteSpace(x.NomeHeroi))
                .WithMessage("O nome do herói deve ter entre 1 e 120 caracteres");

            RuleFor(x => x.Altura)
                .GreaterThan(0)
                .When(x => x.Altura.HasValue)
                .WithMessage("A altura deve ser maior que 0");

            RuleFor(x => x.Peso)
                .GreaterThan(0)
                .When(x => x.Peso.HasValue)
                .WithMessage("O peso deve ser maior que 0");

            RuleFor(x => x.DataNascimento)
                .LessThan(DateTime.Now)
                .When(x => x.DataNascimento.HasValue)
                .WithMessage("A data de nascimento deve ser no passado");
        }
    }
}
