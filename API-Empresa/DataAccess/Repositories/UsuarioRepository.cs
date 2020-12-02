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
        public UsuarioRepository() { }

        public void CadastrarUsuario(Usuario usuario)
        {
            using (var _context = new APIDbContext())
            {
                _context.Add(usuario);
                _context.SaveChanges();
            }
        }

        public List<Usuario> ObterUsuariosCadastrados()
        {
            using (var _context = new APIDbContext())
            {
                return _context.Usuarios.OrderBy(x => x.Nome).ToList();
            }
        }

        public Usuario ObterUsuarioPorId(int id)
        {
            using (var _context = new APIDbContext())
            {
                return _context.Usuarios.Where(x => x.UsuarioId == id).FirstOrDefault();
            }
        }

        public void EditarUsuario(Usuario usuario)
        {
            using (var _context = new APIDbContext())
            {
                _context.Update(usuario);
                _context.SaveChanges();
            }
        }

        public void ExcluirUsuario(Usuario usuario)
        {
            using (var _context = new APIDbContext())
            {
                _context.Update(usuario);
                _context.SaveChanges();
            }
        }
    }
}
