using Core;
using Entity.Interfaces.Repository;
using MediatR;
using Entity.Entities;
using System.Threading;
using System.Threading.Tasks;
using System;
using FluentValidation.Results;

namespace Application.Commands.Administradores
{
    public class AdministradorCommandHandler : 
        IRequestHandler<CadastrarAdministradorCommand, ValidationResult>,
        IRequestHandler<InativarAdministradorCommand, ValidationResult>,
        IRequestHandler<EditarAdministradorCommand, ValidationResult>
    {
        private readonly IAdministradorRepository _administradorRepository;

        public AdministradorCommandHandler(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }

        public async Task<ValidationResult> Handle(CadastrarAdministradorCommand command, CancellationToken cancellationToken)
        {
            if (!command.EhValido()) return command.ValidationResult;

            Administrador administrador = new Administrador(command.Nome, command.Endereco, command.Email);

            _administradorRepository.CadastrarAdministrador(administrador);
            _administradorRepository.Dispose();

            return command.ValidationResult;
        }

        public async Task<ValidationResult> Handle(InativarAdministradorCommand command, CancellationToken cancellationToken)
        {
            if (!command.EhValido()) return command.ValidationResult;

            var administrador = _administradorRepository.ObterAdministradorPorId(command.AdministradorId);

            if (administrador == null) throw new Exception("Nenhum usuário encontrado!");

            administrador.InativarAdministrador();
            _administradorRepository.ExcluirAdministrador(administrador);
            _administradorRepository.Dispose();

            return command.ValidationResult;
        }

        public async Task<ValidationResult> Handle(EditarAdministradorCommand command, CancellationToken cancellationToken)
        {
            if (!command.EhValido()) return command.ValidationResult;

            var administrador = _administradorRepository.ObterAdministradorPorId(command.AdministradorId);

            if (administrador == null) throw new Exception("Nenhum usuário encontrado!");

            var nomeAdministrador = command.Nome != null ? command.Nome : administrador.Nome;
            var enderecoAdministrador = command.Endereco != null ? command.Endereco : administrador.Endereco;
            var emailAdministrador = command.Email != null ? command.Email : administrador.Email;

            administrador.EditarAdministrador(command.AdministradorId, nomeAdministrador, enderecoAdministrador, emailAdministrador);
            _administradorRepository.EditarAdministrador(administrador);
            _administradorRepository.Dispose();

            return command.ValidationResult;
        }
    }
}
