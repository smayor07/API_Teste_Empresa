using Core;
using Entity.Entities;
using Entity.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Filmes
{
    public class FilmeCommandHandler :
        IRequestHandler<VotarFilmeCommand, bool>,
        IRequestHandler<CadastrarFilmeCommand, bool>
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeCommandHandler(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<bool> Handle(VotarFilmeCommand command, CancellationToken cancellationToken)
        {
            if (!ValidarComando(command)) return false;

            var filme = _filmeRepository.ObterFilmePorId(command.FilmeId);

            if (filme != null)
            {
                filme.GravarVoto(command.FilmeId, command.Votos);
                _filmeRepository.GravarVoto(filme);
            }
            _filmeRepository.Dispose();

            return true;
        }

        public async Task<bool> Handle(CadastrarFilmeCommand command, CancellationToken cancellationToken)
        {
            if (!ValidarComando(command)) return false;

            Filme filme = new Filme(command.Nome, command.Genero, command.Diretor, command.Votos);

            _filmeRepository.CadastrarFilme(filme);
            _filmeRepository.Dispose();

            return true;
        }

        private bool ValidarComando(Command command)
        {
            if (command.EhValido()) return true;

            foreach (var item in command.ValidationResult.Errors)
            {
                //lança um evento de erro
            }
            return false;
        }
    }
}
