using Core;
using FluentValidation;

namespace Application.Commands.Filmes
{
    public class VotarFilmeCommand : Command
    {
        public int FilmeId { get; private set; }
        public int Votos { get; private set; }

        public VotarFilmeCommand(int _filmeId, int _voto)
        {
            FilmeId = _filmeId;
            Votos = _voto;
        }

        public override bool EhValido()
        {
            ValidationResult = new VotarFilmeValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class VotarFilmeValidation : AbstractValidator<VotarFilmeCommand>
    {
        public VotarFilmeValidation()
        {
            RuleFor(c => c.FilmeId)
                .NotEmpty()
                .WithMessage("Id filme não pode ser vazio");
            RuleFor(c => c.Votos)
                .GreaterThan(0)
                .WithMessage("O voto mínimo é 1");
        }
    }
}
