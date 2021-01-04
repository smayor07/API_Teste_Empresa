using Entity.Entities;
using Entity.Interfaces.Application;
using Entity.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class AdministradorApplication : IAdministradorApplication
    {
        private readonly IAdministradorRepository _administradorRepository;

        public AdministradorApplication(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }

        public void CadastrarAdministrador(Administrador administrador)
        {
            _administradorRepository.CadastrarAdministrador(administrador);
        }

        public List<Administrador> ObterAdministradoresCadastrados()
        {
            return _administradorRepository.ObterAdministradoresCadastrados();
        }

        public List<Usuario> ObterUsuariosAtivos()
        {
            return _administradorRepository.ObterUsuariosAtivos();
        }

        public Administrador ObterAdministradorPorId(int id)
        {
            return _administradorRepository.ObterAdministradorPorId(id);
        }

        public void EditarAdministrador(Administrador administrador)
        {
            _administradorRepository.EditarAdministrador(administrador);
        }

        public void ExcluirAdministrador(Administrador administrador)
        {
            _administradorRepository.ExcluirAdministrador(administrador);
        }
    }
}
