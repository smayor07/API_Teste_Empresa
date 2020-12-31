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
        private readonly APIDbContext _context;
        public AdministradorRepository(APIDbContext context) 
        {
            _context = context;
        }

        public void CadastrarAdministrador(Administrador administrador)
        {
            _context.Add(administrador);
            _context.SaveChanges();
        }

        public List<Administrador> ObterAdministradoresCadastrados()
        {
            return _context.Administradores.OrderBy(x => x.Nome).ToList();
        }

        public List<Usuario> ObterUsuariosAtivos()
        {
            return _context.Usuarios.Where(x => x.Ativo).OrderBy(x => x.Nome).ToList();
        }

        public Administrador ObterAdministradorPorId(int id)
        {
            return _context.Administradores.Where(x => x.AdministradorId == id).FirstOrDefault();
        }

        public void EditarAdministrador(Administrador administrador)
        {
            _context.Update(administrador);
            _context.SaveChanges();
        }
        public void ExluirAdministrador(Administrador administrador)
        {
            _context.Update(administrador);
            _context.SaveChanges();
        }
    }
}
