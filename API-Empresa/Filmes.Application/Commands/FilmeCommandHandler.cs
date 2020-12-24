using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Filmes.Application.Commands
{
    public class FilmeCommandHandler : IRequestHandler<VotarFilmeCommand, bool>
    {
        public async Task<bool> Handle(VotarFilmeCommand message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
