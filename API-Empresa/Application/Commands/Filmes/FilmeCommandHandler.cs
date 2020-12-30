using Core;
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
        IRequestHandler<VotarFilmeCommand, bool>
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeCommandHandler(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<bool> Handle(VotarFilmeCommand command, CancellationToken cancellationToken)
        {
            if (!ValidarComando(command)) return false;

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
