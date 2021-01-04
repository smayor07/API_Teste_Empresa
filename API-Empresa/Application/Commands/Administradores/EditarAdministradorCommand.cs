using Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Administradores
{
    public class EditarAdministradorCommand : Command
    {
        public int AdministradorId { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Email { get; private set; }

        public EditarAdministradorCommand(int _administradorId, string _nome, string _endereco, string _email)
        {
            AdministradorId = _administradorId;
            Nome = _nome;
            Endereco = _endereco;
            Email = _email;
        }

        public override bool EhValido()
        {
            ValidationResult = new EditarAdministradorValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class EditarAdministradorValidation : AbstractValidator<EditarAdministradorCommand>
    {
        public EditarAdministradorValidation()
        {
            RuleFor(c => c.AdministradorId)
                .NotEmpty()
                .WithMessage("O id do usuario não pode ser vazio");
        }
    }
}
