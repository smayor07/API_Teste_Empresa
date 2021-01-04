using Core;
using FluentValidation;

namespace Application.Commands.Administradores
{
    public class InativarAdministradorCommand : Command
    {
        public int AdministradorId { get; private set; }

        public InativarAdministradorCommand(int _administradorId)
        {
            AdministradorId = _administradorId;
        }

        public override bool EhValido()
        {
            ValidationResult = new InativarAdministradorValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class InativarAdministradorValidation : AbstractValidator<InativarAdministradorCommand>
    {
        public InativarAdministradorValidation()
        {
            RuleFor(c => c.AdministradorId)
                .NotEmpty()
                .WithMessage("Id do usuário não pode ser vazio");
        }
    }
}
