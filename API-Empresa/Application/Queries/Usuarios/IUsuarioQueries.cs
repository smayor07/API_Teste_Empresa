using Application.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Usuarios
{
    public interface IUsuarioQueries
    {
        List<UsuarioViewModel> ObterUsuariosCadastrados();
        UsuarioViewModel ObterUsuarioPorId(int id);
    }
}
