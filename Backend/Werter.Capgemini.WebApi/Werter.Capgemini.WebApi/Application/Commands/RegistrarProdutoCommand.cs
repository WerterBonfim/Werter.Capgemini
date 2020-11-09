using System;
using FluentValidation;
using Werter.Capgemini.WebApi.Core.Messages;

namespace Werter.Capgemini.WebApi.Application.Commands
{
    public class RegistrarProdutoCommand : Command
    {
        public DateTime DataEntrega { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }

        public override bool EValido()
        {
            ValidationResult = new ValidacaoParaRegistrarUmProduto().Validate(this);
            return ValidationResult.IsValid;
        }


        private sealed class ValidacaoParaRegistrarUmProduto : AbstractValidator<RegistrarProdutoCommand>
        {
            public ValidacaoParaRegistrarUmProduto()
            {
                RuleFor(x => x.DataEntrega)
                    .LessThanOrEqualTo(DateTime.Now)
                    .WithMessage("Data inválida. A data fornecida é menor ou igual a data atual");

                RuleFor(x => x.Nome)
                    .MaximumLength(50)
                    .WithMessage("Nome do produto deve ser menor que 50 caracteres");

                RuleFor(x => x.Quantidade)
                    .GreaterThan(0)
                    .WithMessage("Quantidade deve ser maior que zero");
                
                RuleFor(x => x.ValorUnitario)
                    .GreaterThan(0)
                    .WithMessage("Valor unitário deve ser maior que zero");
            }
        }
        
    }
}