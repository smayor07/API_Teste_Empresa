using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity.Interfaces.Application
{
    public interface IAdministradorApplication
    {
        void CadastrarAdministrador(Administrador administrador);
        List<Administrador> ObterAdministradoresCadastrados();
        List<Usuario> ObterUsuariosAtivos();
        Administrador ObterAdministradorPorId(int id);
        void EditarAdministrador(Administrador administrador);
        void ExcluirAdministrador(Administrador administrador);
    }
}
