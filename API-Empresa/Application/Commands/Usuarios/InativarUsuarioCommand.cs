using Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Usuarios
{
    public class InativarUsuarioCommand : Command
    {
        public int UsuarioId { get; set; }

        public InativarUsuarioCommand(int _usuarioId)
        {
            UsuarioId = _usuarioId;
        }

        public override bool EhValido()
        {
            ValidationResult = new VotarFilmeValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class VotarFilmeValidation : AbstractValidator<InativarUsuarioCommand>
    {
        public VotarFilmeValidation()
        {
            RuleFor(c => c.UsuarioId)
                .NotEmpty()
                .WithMessage("Id do usuário não pode ser vazio");
        }
    }
}
