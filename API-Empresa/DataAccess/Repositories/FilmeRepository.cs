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
        private readonly APIDbContext _context;
        public FilmeRepository(APIDbContext context) 
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork { get; }

        public void CadastrarFilme(Filme filme)
        {
            _context.Add(filme);
            _context.SaveChanges();
        }

        public Filme ObterFilmePorId(int id)
        {
            return _context.Filmes.Where(x => x.FilmeId == id).FirstOrDefault();
        }
        public void GravarVoto(Filme filme)
        {
            _context.Update(filme);
            _context.SaveChanges();
        }

        public List<Filme> BuscarFilmePorNome(string nome)
        {
            return _context.Filmes
                    .Where(x => x.Nome.Equals(nome))
                    .OrderBy(x => x.Nome)
                    .ToList();
        }
        public List<Filme> BuscarFilmePorGenero(string genero)
        {
            return _context.Filmes
                    .Where(x => x.Genero.Equals(genero))
                    .OrderBy(x => x.Nome)
                    .ToList();
        }
        public List<Filme> BuscarFilmePorDiretor(string diretor)
        {
            return _context.Filmes
                    .Where(x => x.Diretor.Equals(diretor))
                    .OrderBy(x => x.Nome)
                    .ToList();
        }

        public List<Filme> BuscarTodosFilmes()
        {
            return _context.Filmes
                    .OrderBy(x => x.Nome)
                    .ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
