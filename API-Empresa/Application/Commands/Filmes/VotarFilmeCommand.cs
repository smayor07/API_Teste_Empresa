using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Filmes
{
    public class VotarFilmeCommand : Command
    {
        public int FilmeId { get; set; }
        public int Votos { get; set; }

        public VotarFilmeCommand(int _filmeId, int _voto)
        {
            FilmeId = _filmeId;
            Votos = _voto;
        }
    }
}
