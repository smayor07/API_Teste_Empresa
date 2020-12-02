using DataAccess.Context;
using Entity.Entities;
using Entity.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class AdministradorRepository : IAdministradorRepository
    {
        public AdministradorRepository() { }
        public void CadastrarAdministrador(Administrador administrador)
        {
            using (var _context = new APIDbContext())
            {
                _context.Add(administrador);
                _context.SaveChanges();
            }
        }

        public List<Administrador> ObterAdministradoresCadastrados()
        {
            using (var _context = new APIDbContext())
            {
                return _context.Administradores.OrderBy(x => x.Nome).ToList();
            }
        }

        public List<Usuario> ObterUsuariosAtivos()
        {
            using (var _context = new APIDbContext())
            {
                return _context.Usuarios.Where(x => x.Ativo).OrderBy(x => x.Nome).ToList();
            }
        }

        public Administrador ObterAdministradorPorId(int id)
        {
            using (var _context = new APIDbContext())
            {
                return _context.Administradores.Where(x => x.AdministradorId == id).FirstOrDefault();
            }
        }

        public void EditarAdministrador(Administrador administrador)
        {
            using (var _context = new APIDbContext())
            {
                _context.Update(administrador);
                _context.SaveChanges();
            }
        }
        public void ExluirAdministrador(Administrador administrador)
        {
            using (var _context = new APIDbContext())
            {
                _context.Update(administrador);
                _context.SaveChanges();
            }
        }
    }
}
