using Core;
using Entity.Entities;
using Entity.Interfaces.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Application.Commands.Filmes
{
    public class FilmeCommandHandler :
        IRequestHandler<VotarFilmeCommand, ValidationResult>,
        IRequestHandler<CadastrarFilmeCommand, ValidationResult>
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeCommandHandler(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<ValidationResult> Handle(VotarFilmeCommand command, CancellationToken cancellationToken)
        {
            if (!command.EhValido()) return command.ValidationResult;

            var filme = _filmeRepository.ObterFilmePorId(command.FilmeId);

            if (filme != null)
            {
                filme.GravarVoto(command.FilmeId, command.Votos);
                _filmeRepository.GravarVoto(filme);
            }
            _filmeRepository.Dispose();

            return command.ValidationResult;
        }

        public async Task<ValidationResult> Handle(CadastrarFilmeCommand command, CancellationToken cancellationToken)
        {
            if (!command.EhValido()) return command.ValidationResult;

            Filme filme = new Filme(command.Nome, command.Genero, command.Diretor, command.Votos);

            _filmeRepository.CadastrarFilme(filme);
            _filmeRepository.Dispose();

            return command.ValidationResult;
        }
    }
}
