using System;
using System.Collections.Generic;
using System.Text;

namespace Filmes.Domain
{
    public class Filme
    {
        public int FilmeId { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Diretor { get; set; }
        public int Votos { get; set; }

        public Filme(string _nome, string _genero, string _diretor, int _votos)
        {
            Nome = _nome;
            Genero = _genero;
            Diretor = _diretor;
            Votos = _votos;
        }

        protected Filme() { }

        public void setVoto(VotoEnum voto)
        {
            Votos += (int)voto;
        }
    }
}
