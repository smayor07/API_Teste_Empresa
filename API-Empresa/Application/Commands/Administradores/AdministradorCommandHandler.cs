using Core;
using Entity.Interfaces.Repository;
using MediatR;
using Entity.Entities;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Application.Commands.Administradores
{
    public class AdministradorCommandHandler : 
        IRequestHandler<CadastrarAdministradorCommand, bool>,
        IRequestHandler<InativarAdministradorCommand, bool>,
        IRequestHandler<EditarAdministradorCommand, bool>
    {
        private readonly IAdministradorRepository _administradorRepository;

        public AdministradorCommandHandler(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }

        public async Task<bool> Handle(CadastrarAdministradorCommand command, CancellationToken cancellationToken)
        {
            if (!ValidarComando(command)) return false;

            Administrador administrador = new Administrador(command.Nome, command.Endereco, command.Email);

            _administradorRepository.CadastrarAdministrador(administrador);
            _administradorRepository.Dispose();

            return true;
        }

        public async Task<bool> Handle(InativarAdministradorCommand command, CancellationToken cancellationToken)
        {
            if (!ValidarComando(command)) return false;

            var administrador = _administradorRepository.ObterAdministradorPorId(command.AdministradorId);

            if (administrador == null) throw new Exception("Nenhum usuário encontrado!");

            administrador.InativarAdministrador();
            _administradorRepository.ExcluirAdministrador(administrador);
            _administradorRepository.Dispose();

            return true;
        }

        public async Task<bool> Handle(EditarAdministradorCommand command, CancellationToken cancellationToken)
        {
            if (!ValidarComando(command)) return false;

            var administrador = _administradorRepository.ObterAdministradorPorId(command.AdministradorId);

            if (administrador == null) throw new Exception("Nenhum usuário encontrado!");

            var nomeAdministrador = command.Nome != null ? command.Nome : administrador.Nome;
            var enderecoAdministrador = command.Endereco != null ? command.Endereco : administrador.Endereco;
            var emailAdministrador = command.Email != null ? command.Email : administrador.Email;

            administrador.EditarAdministrador(command.AdministradorId, nomeAdministrador, enderecoAdministrador, emailAdministrador);
            _administradorRepository.EditarAdministrador(administrador);
            _administradorRepository.Dispose();

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
