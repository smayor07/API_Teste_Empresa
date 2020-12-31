using Entity.Entities;
using Entity.Interfaces.Application;
using Entity.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class FilmeApplication : IFilmeApplication
    {
        private readonly IFilmeRepository _filmeRepository;
        public FilmeApplication(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public void CadastrarFilme(Filme filme)
        {
            _filmeRepository.CadastrarFilme(filme);
        }

        public Filme ObterFilmePorId(int id)
        {
            return _filmeRepository.ObterFilmePorId(id);
        }

        public void GravarVoto(Filme filme)
        {
            _filmeRepository.GravarVoto(filme);
        }

        public List<Filme> BuscarFilmePorNome(string nome)
        {
            return _filmeRepository.BuscarFilmePorNome(nome);
        }
        public List<Filme> BuscarFilmePorGenero(string genero)
        {
            return _filmeRepository.BuscarFilmePorGenero(genero);
        }
        public List<Filme> BuscarFilmePorDiretor(string diretor)
        {
            return _filmeRepository.BuscarFilmePorDiretor(diretor);
        }

        public List<Filme> BuscarTodosFilmes()
        {
            return _filmeRepository.BuscarTodosFilmes();
        }
        public void Dispose()
        {
            _filmeRepository?.Dispose();
        }
    }
}
