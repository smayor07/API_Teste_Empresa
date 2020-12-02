using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        void CadastrarUsuario(Usuario usuario);
        List<Usuario> ObterUsuariosCadastrados();
        Usuario ObterUsuarioPorId(int id);
        void EditarUsuario(Usuario usuario);
        void ExcluirUsuario(Usuario usuario);
        
    }
}
