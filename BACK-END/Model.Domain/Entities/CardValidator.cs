using FluentValidation;

namespace Model.Domain.Entities
{
    public class CardValidator : AbstractValidator<Card>
    {
        public CardValidator()
        {
            RuleFor(x => x.Conteudo)
                .NotEmpty().WithMessage("Conteúdo não pode ser vazio.");

            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("Título não pode ser vazio.");

            RuleFor(x => x.Lista)
                .NotEmpty().WithMessage("Lista não pode ser vazio.");
        }
    }
}
