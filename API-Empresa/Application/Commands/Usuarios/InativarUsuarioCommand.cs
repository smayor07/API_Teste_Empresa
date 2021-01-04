using Core;
using FluentValidation;

namespace Application.Commands.Usuarios
{
    public class InativarUsuarioCommand : Command
    {
        public int UsuarioId { get; private set; }

        public InativarUsuarioCommand(int _usuarioId)
        {
            UsuarioId = _usuarioId;
        }

        public override bool EhValido()
        {
            ValidationResult = new InativarUsuarioValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class InativarUsuarioValidation : AbstractValidator<InativarUsuarioCommand>
    {
        public InativarUsuarioValidation()
        {
            RuleFor(c => c.UsuarioId)
                .NotEmpty()
                .WithMessage("Id do usuário não pode ser vazio");
        }
    }
}
