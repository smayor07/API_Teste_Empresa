using Application.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Administradores
{
    public interface IAdministradorQueries
    {
        List<AdministradorViewModel> ObterAdministradoresCadastrados();
        List<UsuarioViewModel> ObterUsuariosAtivos();
        AdministradorViewModel ObterAdministradorPorId(int id);
    }
}
