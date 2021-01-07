using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Integration.Filmes
{
    public class VotoFilmeIntegrationEvent : IntegrationEvent
    {
        public int FilmeId { get; private set; }
        public int Votos { get; private set; }

        public VotoFilmeIntegrationEvent(int _filmeId, int _votos)
        {
            FilmeId = _filmeId;
            Votos = _votos;
        }
    }
}
