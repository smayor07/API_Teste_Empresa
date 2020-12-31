using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    public class Filme : IAggregateRoot
    {
        public int FilmeId { get; private set; }
        public string Nome { get; private set; }
        public string Genero { get; private set; }
        public string Diretor { get; private set; }
        public int Votos { get; private set; }

        protected Filme() { }

        public Filme(int _filmeId, string _nome, string _genero, string _diretor, int _votos)
        {
            FilmeId = _filmeId;
            Nome = _nome;
            Genero = _genero;
            Diretor = _diretor;
            Votos = _votos;

            Validar();
        }

        public void GravarVoto(int filmeId, int voto)
        {
            FilmeId = filmeId;
            Votos += voto;
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(FilmeId.ToString(), "O id do filme não pode estar vazio");
            Validacoes.ValidarSeVazio(Nome, "O nome do filme não pode estar vazio");
            Validacoes.ValidarSeVazio(Genero, "O genero não pode estar vazio");
            Validacoes.ValidarSeVazio(Diretor, "O nome do diretor não pode estar vazio");
            Validacoes.ValidarSeMenorIgualMinimo(Votos, 1, "O valor do voto não pode ser zero");
        }
    }
}
