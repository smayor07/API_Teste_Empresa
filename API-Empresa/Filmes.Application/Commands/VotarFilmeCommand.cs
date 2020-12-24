using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filmes.Application.Commands
{
    public class VotarFilmeCommand : Command
    {
        public int Votos { get; set; }

        public VotarFilmeCommand(int _voto)
        {
            Votos = _voto;
        }
    }
}
