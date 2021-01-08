using Core;
using Entity.Entities;
using Entity.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Application.Commands.Usuarios
{
    public class UsuarioCommandHandler : 
        IRequestHandler<CadastrarUsuarioCommand, ValidationResult>,
        IRequestHandler<InativarUsuarioCommand, ValidationResult>,
        IRequestHandler<EditarUsuarioCommand, ValidationResult>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ValidationResult> Handle(CadastrarUsuarioCommand command, CancellationToken cancellationToken)
        {
            if (!command.EhValido()) return command.ValidationResult;

            Usuario usuario = new Usuario(command.Nome, command.Endereco, command.Email);

            _usuarioRepository.CadastrarUsuario(usuario);
            _usuarioRepository.Dispose();

            return command.ValidationResult;
        }
        public async Task<ValidationResult> Handle(InativarUsuarioCommand command, CancellationToken cancellationToken)
        {
            if (!command.EhValido()) return command.ValidationResult;

            var usuario = _usuarioRepository.ObterUsuarioPorId(command.UsuarioId);

            if (usuario == null) throw new Exception("Nenhum usuário encontrado!");

            usuario.InativarUsuario();
            _usuarioRepository.ExcluirUsuario(usuario);
            _usuarioRepository.Dispose();

            return command.ValidationResult;
        }
        public async Task<ValidationResult> Handle(EditarUsuarioCommand command, CancellationToken cancellationToken)
        {
            if (!command.EhValido()) return command.ValidationResult;

            var usuario = _usuarioRepository.ObterUsuarioPorId(command.UsuarioId);

            if (usuario == null) throw new Exception("Nenhum usuário encontrado!");

            var nomeUsuario = command.Nome != null ? command.Nome : usuario.Nome;
            var enderecoUsuario = command.Endereco != null ? command.Endereco : usuario.Endereco;
            var emailUsuario = command.Email != null ? command.Email : usuario.Email;

            usuario.EditarUsuario(command.UsuarioId, nomeUsuario, enderecoUsuario, emailUsuario);
            _usuarioRepository.EditarUsuario(usuario);
            _usuarioRepository.Dispose();

            return command.ValidationResult;
        }
    }
}
