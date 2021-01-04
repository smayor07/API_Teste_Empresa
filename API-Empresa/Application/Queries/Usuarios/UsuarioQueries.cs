using Application.Queries.ViewModels;
using Entity.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Queries.Usuarios
{
    public class UsuarioQueries : IUsuarioQueries
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioQueries(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public UsuarioViewModel ObterUsuarioPorId(int id)
        {
            var usuario = _usuarioRepository.ObterUsuarioPorId(id);

            if (usuario == null) throw new Exception("Nenhum usuário encontrado!");

            var usuarioVm = new UsuarioViewModel
            {
                Nome = usuario.Nome,
                Endereco = usuario.Endereco,
                Email = usuario.Email,
                Ativo = usuario.Ativo
            };

            return usuarioVm;
        }

        public List<UsuarioViewModel> ObterUsuariosCadastrados()
        {
            var usuarios = _usuarioRepository.ObterUsuariosCadastrados();

            if (!usuarios.Any()) throw new Exception("Nenhum usuário encontrado!");

            var listUsuariosVm = new List<UsuarioViewModel>();

            foreach (var item in usuarios)
            {
                listUsuariosVm.Add(new UsuarioViewModel
                {
                    Nome = item.Nome,
                    Endereco = item.Endereco,
                    Email = item.Email,
                    Ativo = item.Ativo
                });
            }

            return listUsuariosVm;
        }
    }
}
