using Core.Data;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class APIDbContext : DbContext
    {
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Filme> Filmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                //.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=api_ioasys;Integrated Security=True");
                .UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=api_ioasys;Integrated Security=True");
        }
    }
}
