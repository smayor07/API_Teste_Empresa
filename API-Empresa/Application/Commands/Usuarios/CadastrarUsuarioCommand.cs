using Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Usuarios
{
    public class CadastrarUsuarioCommand : Command
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

        public CadastrarUsuarioCommand(string _nome, string _endereco, string _email)
        {
            Nome = _nome;
            Endereco = _endereco;
            Email = _email;
            Ativo = true;
        }

        public override bool EhValido()
        {
            ValidationResult = new CadastrarUsuarioValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CadastrarUsuarioValidation : AbstractValidator<CadastrarUsuarioCommand>
    {
        public CadastrarUsuarioValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do usuario não pode ser vazio");
            RuleFor(c => c.Endereco)
                .NotEmpty()
                .WithMessage("O endereço do usuario não pode ser vazio");
            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("O email do usuario não pode ser vazio");
        }
    }
}
