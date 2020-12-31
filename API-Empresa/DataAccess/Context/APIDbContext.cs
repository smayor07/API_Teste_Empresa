using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public class APIDbContext : DbContext
    {
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Filme> Filmes { get; set; }

        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                //.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=api_ioasys;Integrated Security=True");
                .UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=api_ioasys;Integrated Security=True");
        }
    }
}
