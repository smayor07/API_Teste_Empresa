using Application.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Filmes
{
    public interface IFilmeQueries
    {
        FilmeViewModel ObterFilmePorId(int id);
        List<FilmeViewModel> BuscarFilmePorNome(string nome);
        List<FilmeViewModel> BuscarFilmePorGenero(string genero);
        List<FilmeViewModel> BuscarFilmePorDiretor(string diretor);
        List<FilmeViewModel> BuscarTodosFilmes();
    }
}
