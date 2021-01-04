using Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Usuarios
{
    public class EditarUsuarioCommand : Command
    {
        public int UsuarioId { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Email { get; private set; }

        public EditarUsuarioCommand(int _usuarioId, string _nome, string _endereco, string _email)
        {
            UsuarioId = _usuarioId;
            Nome = _nome;
            Endereco = _endereco;
            Email = _email;
        }

        public override bool EhValido()
        {
            ValidationResult = new EditarUsuarioValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class EditarUsuarioValidation : AbstractValidator<EditarUsuarioCommand>
    {
        public EditarUsuarioValidation()
        {
            RuleFor(c => c.UsuarioId)
                .NotEmpty()
                .WithMessage("O id do usuario não pode ser vazio");
        }
    }
}
