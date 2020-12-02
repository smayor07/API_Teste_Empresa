using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Interfaces.Repository
{
    public interface IFilmeRepository
    {
        void CadastrarFilme(Filme filme);
        Filme ObterFilmePorId(int id);
        void GravarVoto(Filme filme);
        List<Filme> BuscarFilmePorNome(string nome);
        List<Filme> BuscarFilmePorGenero(string genero);
        List<Filme> BuscarFilmePorDiretor(string diretor);
        List<Filme> BuscarTodosFilmes();
    }
}
