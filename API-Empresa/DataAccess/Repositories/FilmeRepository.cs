using Core.Data;
using DataAccess.Context;
using Entity.Entities;
using Entity.Interfaces.Repository;
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        public FilmeRepository() {}

        public void CadastrarFilme(Filme filme)
        {
            using (var _context = new APIDbContext())
            {
                _context.Add(filme);
                _context.SaveChanges();
            }
        }

        public Filme ObterFilmePorId(int id)
        {
            using (var _context = new APIDbContext())
            {
                return _context.Filmes.Where(x => x.FilmeId == id).FirstOrDefault();
            }
        }
        public void GravarVoto(Filme filme)
        {
            using (var _context = new APIDbContext())
            {
                _context.Update(filme);
                _context.SaveChanges();
            }
        }

        public List<Filme> BuscarFilmePorNome(string nome)
        {
            using (var _context = new APIDbContext())
            {
                return _context.Filmes
                    .Where(x => x.Nome.Equals(nome))
                    .OrderBy(x => x.Nome)
                    .ToList();
            }
        }
        public List<Filme> BuscarFilmePorGenero(string genero)
        {
            using (var _context = new APIDbContext())
            {
                return _context.Filmes
                    .Where(x => x.Genero.Equals(genero))
                    .OrderBy(x => x.Nome)
                    .ToList();
            }
        }
        public List<Filme> BuscarFilmePorDiretor(string diretor)
        {
            using (var _context = new APIDbContext())
            {
                return _context.Filmes
                    .Where(x => x.Diretor.Equals(diretor))
                    .OrderBy(x => x.Nome)
                    .ToList();
            }
        }

        public List<Filme> BuscarTodosFilmes()
        {
            using (var _context = new APIDbContext())
            {
                return _context.Filmes
                    .OrderBy(x => x.Nome)
                    .ToList();
            }
        }

        public void Dispose()
        {
            using (var _context = new APIDbContext())
            {
                _context.Dispose();
            }
        }
    }
}
