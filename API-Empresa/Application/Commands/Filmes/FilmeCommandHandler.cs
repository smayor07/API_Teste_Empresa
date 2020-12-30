using Entity.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Filmes
{
    public class FilmeCommandHandler : IRequestHandler<VotarFilmeCommand, bool>
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeCommandHandler(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }
        public async Task<bool> Handle(VotarFilmeCommand message, CancellationToken cancellationToken)
        {
            var filme = _filmeRepository.ObterFilmePorId(message.FilmeId);

            if (filme == null) return false;

            filme.Votos += message.Votos;
            _filmeRepository.GravarVoto(filme);
            return true;
        }
    }
}
