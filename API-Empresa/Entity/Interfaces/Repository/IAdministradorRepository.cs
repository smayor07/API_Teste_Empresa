using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity.Interfaces.Repository
{
    public interface IAdministradorRepository
    {
        void CadastrarAdministrador(Administrador administrador);
        List<Usuario> ObterUsuariosAtivos();
        Administrador ObterAdministradorPorId(int id);
        void EditarAdministrador(Administrador administrador);
        void ExluirAdministrador(Administrador administrador);
        List<Administrador> ObterAdministradoresCadastrados();
    }
}
