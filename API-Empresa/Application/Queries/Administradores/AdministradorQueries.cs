using Application.Queries.ViewModels;
using Entity.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Queries.Administradores
{
    public class AdministradorQueries : IAdministradorQueries
    {
        private readonly IAdministradorRepository _administradorRepository;

        public AdministradorQueries(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }

        public AdministradorViewModel ObterAdministradorPorId(int id)
        {
            var administrador = _administradorRepository.ObterAdministradorPorId(id);

            if (administrador == null) throw new Exception("Nenhum administrador encontrado!");

            var administradorVm = new AdministradorViewModel
            {
                AdministradorId = administrador.AdministradorId,
                Nome = administrador.Nome,
                Endereco = administrador.Endereco,
                Email = administrador.Email,
                Ativo = administrador.Ativo
            };

            return administradorVm;
        }

        public List<AdministradorViewModel> ObterAdministradoresCadastrados()
        {
            var administrador = _administradorRepository.ObterAdministradoresCadastrados();

            if (!administrador.Any()) throw new Exception("Nenhum administrador encontrado!");

            var listAdministradoresVm = new List<AdministradorViewModel>();

            foreach (var item in administrador)
            {
                listAdministradoresVm.Add(new AdministradorViewModel
                {
                    AdministradorId = item.AdministradorId,
                    Nome = item.Nome,
                    Endereco = item.Endereco,
                    Email = item.Email,
                    Ativo = item.Ativo
                });
            }

            return listAdministradoresVm;
        }

        public List<UsuarioViewModel> ObterUsuariosAtivos()
        {
            var usuariosAtivos = _administradorRepository.ObterUsuariosAtivos();

            if (!usuariosAtivos.Any()) throw new Exception("Nenhum usuário ativo encontrado!");

            var listUsuariosAtivos = new List<UsuarioViewModel>();

            foreach (var item in usuariosAtivos)
            {
                listUsuariosAtivos.Add(new UsuarioViewModel
                {
                    UsuarioId = item.UsuarioId,
                    Nome = item.Nome,
                    Endereco = item.Endereco,
                    Email = item.Email,
                    Ativo = item.Ativo
                });
            }

            return listUsuariosAtivos;
        }
    }
}
