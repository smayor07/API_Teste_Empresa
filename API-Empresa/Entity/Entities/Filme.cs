using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    public class Filme
    {
        public int FilmeId { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Diretor { get; set; }
        public int Votos { get; set; }
    }
}
