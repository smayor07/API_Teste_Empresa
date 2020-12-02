using Entity.Entities;
using Entity.Interfaces.Application;
using Entity.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioApplication(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            _usuarioRepository.CadastrarUsuario(usuario);
        }

        public List<Usuario> ObterUsuariosCadastrados()
        {
            return _usuarioRepository.ObterUsuariosCadastrados();
        }

        public Usuario ObterUsuarioPorId(int id)
        {
            return _usuarioRepository.ObterUsuarioPorId(id);
        }
        public void EditarUsuario(Usuario usuario)
        {
            _usuarioRepository.EditarUsuario(usuario);
        }
        public void ExcluirUsuario(Usuario usuario)
        {
            _usuarioRepository.ExcluirUsuario(usuario);
        }
    }
}
