using Application.Queries.ViewModels;
using Entity.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Queries.Filmes
{
    public class FilmeQueries : IFilmeQueries
    {
        private readonly IFilmeRepository _filmeRepository;
        public FilmeQueries(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public FilmeViewModel ObterFilmePorId(int id)
        {
            var filme = _filmeRepository.ObterFilmePorId(id);

            if (filme == null) throw new Exception("Nenhum filme encontrado!");

            var filmeVm = new FilmeViewModel
            {
                FilmeId = filme.FilmeId,
                Nome = filme.Nome,
                Diretor = filme.Diretor,
                Genero = filme.Genero,
                Votos = filme.Votos
            };

            return filmeVm;
        }

        public List<FilmeViewModel> BuscarFilmePorDiretor(string diretor)
        {
            var filmes = _filmeRepository.BuscarFilmePorDiretor(diretor);

            if (!filmes.Any()) throw new Exception("Nenhum filme encontrado!");

            var listFilmesVm = new List<FilmeViewModel>();

            foreach (var item in filmes)
            {
                listFilmesVm.Add(new FilmeViewModel
                {
                    FilmeId = item.FilmeId,
                    Nome = item.Nome,
                    Diretor = item.Diretor,
                    Genero = item.Genero,
                    Votos = item.Votos
                });
            }

            return listFilmesVm;
        }

        public List<FilmeViewModel> BuscarFilmePorGenero(string genero)
        {
            var filmes = _filmeRepository.BuscarFilmePorGenero(genero);

            if (!filmes.Any()) throw new Exception("Nenhum filme encontrado!");

            var listFilmesVm = new List<FilmeViewModel>();

            foreach (var item in filmes)
            {
                listFilmesVm.Add(new FilmeViewModel
                {
                    FilmeId = item.FilmeId,
                    Nome = item.Nome,
                    Diretor = item.Diretor,
                    Genero = item.Genero,
                    Votos = item.Votos
                });
            }

            return listFilmesVm;
        }

        public List<FilmeViewModel> BuscarFilmePorNome(string nome)
        {
            var filmes = _filmeRepository.BuscarFilmePorNome(nome);

            if (!filmes.Any()) throw new Exception("Nenhum filme encontrado!");

            var listFilmesVm = new List<FilmeViewModel>();

            foreach (var item in filmes)
            {
                listFilmesVm.Add(new FilmeViewModel
                {
                    FilmeId = item.FilmeId,
                    Nome = item.Nome,
                    Diretor = item.Diretor,
                    Genero = item.Genero,
                    Votos = item.Votos
                });
            }

            return listFilmesVm;
        }

        public List<FilmeViewModel> BuscarTodosFilmes()
        {
            var filmes = _filmeRepository.BuscarTodosFilmes();

            if (!filmes.Any()) throw new Exception("Nenhum filme encontrado!");

            var listFilmesVm = new List<FilmeViewModel>();

            foreach (var item in filmes)
            {
                listFilmesVm.Add(new FilmeViewModel
                {
                    FilmeId = item.FilmeId,
                    Nome = item.Nome,
                    Diretor = item.Diretor,
                    Genero = item.Genero,
                    Votos = item.Votos
                });
            }

            return listFilmesVm;
        }
    }
}
