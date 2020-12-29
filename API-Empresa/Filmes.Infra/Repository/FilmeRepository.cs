using DataAccess.Context;
using Filmes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filmes.Infra.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly APIDbContext _context;

        public FilmeRepository(APIDbContext context)
        {
            _context = context;
        }

        public void setVoto(VotoEnum voto)
        {

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
