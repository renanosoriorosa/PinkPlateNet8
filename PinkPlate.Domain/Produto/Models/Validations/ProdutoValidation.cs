using FluentValidation;

namespace PinkPlate.Domain.Produto.Models.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation() 
        {
            RuleFor(c => c.Codigo)
                    .NotEmpty().WithMessage("O campo código precisa ser fornecido")
                    .Length(3, 15).WithMessage("O campo código precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Descricao)
                .Length(3, 500).WithMessage("O campo descrição precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
