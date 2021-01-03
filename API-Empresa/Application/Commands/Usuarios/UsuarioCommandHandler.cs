using Core;
using Entity.Entities;
using Entity.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Usuarios
{
    public class UsuarioCommandHandler : 
        IRequestHandler<CadastrarUsuarioCommand, bool>,
        IRequestHandler<InativarUsuarioCommand, bool>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(CadastrarUsuarioCommand command, CancellationToken cancellationToken)
        {
            if (!ValidarComando(command)) return false;

            Usuario usuario = new Usuario(command.Nome, command.Endereco, command.Email);

            _usuarioRepository.CadastrarUsuario(usuario);
            _usuarioRepository.Dispose();

            return true;
        }

        public async Task<bool> Handle(InativarUsuarioCommand command, CancellationToken cancellationToken)
        {
            if (!ValidarComando(command)) return false;

            var usuario = _usuarioRepository.ObterUsuarioPorId(command.UsuarioId);

            if (usuario != null)
            {
                usuario.InativarUsuario();
                _usuarioRepository.ExcluirUsuario(usuario);
                _usuarioRepository.Dispose();
            }

            return true;
        }

        private bool ValidarComando(Command command)
        {
            if (command.EhValido()) return true;

            foreach (var item in command.ValidationResult.Errors)
            {
                //lança um evento de erro
            }
            return false;
        }
    }
}
