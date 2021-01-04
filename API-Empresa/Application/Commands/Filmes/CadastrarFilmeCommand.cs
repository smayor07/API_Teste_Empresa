using Core;
using Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Filmes
{
    public class CadastrarFilmeCommand : Command
    {
        public string Nome { get; private set; }
        public string Genero { get; private set; }
        public string Diretor { get; private set; }
        public int Votos { get; private set; }

        public CadastrarFilmeCommand(string _nome, string _genero, string _diretor)
        {
            Nome = _nome;
            Genero = _genero;
            Diretor = _diretor;
            Votos = 0;
        }

        public override bool EhValido()
        {
            ValidationResult = new CadastrarFilmeValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CadastrarFilmeValidation : AbstractValidator<CadastrarFilmeCommand>
    {
        public CadastrarFilmeValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do filme não pode ser vazio");
            RuleFor(c => c.Diretor)
                .NotEmpty()
                .WithMessage("O diretor do filme não pode ser vazio");
            RuleFor(c => c.Genero)
                .NotEmpty()
                .WithMessage("O gênero do filme não pode ser vazio");
        }
    }
}
