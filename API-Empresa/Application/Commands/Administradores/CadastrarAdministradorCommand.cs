using Core;
using FluentValidation;

namespace Application.Commands.Administradores
{
    public class CadastrarAdministradorCommand : Command
    {
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }

        public CadastrarAdministradorCommand(string _nome, string _endereco, string _email)
        {
            Nome = _nome;
            Endereco = _endereco;
            Email = _email;
            Ativo = true;
        }

        public override bool EhValido()
        {
            ValidationResult = new CadastrarAdministradorValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CadastrarAdministradorValidation : AbstractValidator<CadastrarAdministradorCommand>
    {
        public CadastrarAdministradorValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do administrador não pode ser vazio");
            RuleFor(c => c.Endereco)
                .NotEmpty()
                .WithMessage("O endereço do administrador não pode ser vazio");
            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("O email do administrador não pode ser vazio");
        }
    }
}
