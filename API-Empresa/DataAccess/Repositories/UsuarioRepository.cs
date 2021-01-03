using DataAccess.Context;
using Entity.Entities;
using Entity.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly APIDbContext _context;
        public UsuarioRepository(APIDbContext context) 
        {
            _context = context;
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
        }

        public List<Usuario> ObterUsuariosCadastrados()
        {
            return _context.Usuarios.OrderBy(x => x.Nome).ToList();
        }

        public Usuario ObterUsuarioPorId(int id)
        {
            return _context.Usuarios.Where(x => x.UsuarioId == id).FirstOrDefault();
        }

        public void EditarUsuario(Usuario usuario)
        {
            _context.Update(usuario);
            _context.SaveChanges();
        }

        public void ExcluirUsuario(Usuario usuario)
        {
            _context.Update(usuario);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
