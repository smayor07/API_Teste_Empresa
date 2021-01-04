using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Application.Commands.Administradores;
using Application.Queries.Administradores;
using Core.Bus;
using Entity.Entities;
using Entity.Interfaces.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IAdministradorQueries _administradorQueries;

        public AdministradorController(IMediatorHandler mediatorHandler, IAdministradorQueries administradorQueries)
        {
            _administradorQueries = administradorQueries;
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet]
        [Route("ListarAdministradores")]
        public BaseResponse ListarAdministradores()
        {
            var resp = new BaseResponse();

            try
            {
                var administradores = _administradorQueries.ObterAdministradoresCadastrados();

                var obj = new
                {
                    Adm = administradores
                };

                resp.Valor = obj;
                resp.Mensagem = $"A consulta retornou {administradores.Count} resultados";
                resp.Sucesso = true;
            }
            catch (Exception ex)
            {
                resp.Mensagem = ex.Message;
                resp.Sucesso = false;
                throw;
            }
            return resp;
        }

        [HttpPost]
        [Route("CadastrarAdministrador")]
        public BaseResponse CriarAdministrador(string nome, string endereco, string email)
        {
            var resp = new BaseResponse();
            try
            {
                var command = new CadastrarAdministradorCommand(nome, endereco, email);
                _mediatorHandler.EnviarComando(command);

                var obj = new
                {
                    Adm = command
                };

                resp.Valor = obj;
                resp.Mensagem = "Administrador cadastrado com sucesso!";
                resp.Sucesso = true;
            }
            catch (Exception ex)
            {
                resp.Mensagem = ex.Message;
                resp.Sucesso = false;
                throw;
            }
            return resp;
        }

        [HttpGet]
        [Route("ObterUsuariosAtivos")]
        public BaseResponse ObterUsuariosAtivos()
        {
            var resp = new BaseResponse();

            try
            {
                var usuarios = _administradorQueries.ObterUsuariosAtivos();

                var obj = new
                {
                    UsuariosAtivos = usuarios
                };

                resp.Valor = obj;
                resp.Mensagem = $"A consulta retornou {usuarios.Count} resultados";
                resp.Sucesso = true;
            }
            catch (Exception ex)
            {
                resp.Mensagem = ex.Message;
                resp.Sucesso = false;
                throw;
            }
            return resp;
        }

        [HttpPut]
        [Route("EditarAdministrador")]
        public BaseResponse EditarAdministrador(int id, string nome = null, string endereco = null, string email = null)
        {
            var resp = new BaseResponse();

            try
            {
                var command = new EditarAdministradorCommand(id, nome, endereco, email);
                _mediatorHandler.EnviarComando(command);

                var obj = new
                {
                    Adm = command
                };

                resp.Valor = obj;
                resp.Mensagem = "Administrador editado com sucesso!";
                resp.Sucesso = true;
            }
            catch (Exception ex)
            {
                resp.Mensagem = ex.Message;
                resp.Sucesso = false;
                throw;
            }
            return resp;
        }

        [HttpDelete]
        [Route("ExcluirAdministrador")]
        public BaseResponse ExcluirAdministrador(int id)
        {
            var resp = new BaseResponse();
            try
            {
                var command = new InativarAdministradorCommand(id);
                _mediatorHandler.EnviarComando(command);

                var obj = new
                {
                    Adm = command
                };

                resp.Valor = obj;
                resp.Mensagem = "Administrador excluído com sucesso!";
                resp.Sucesso = true;
            }
            catch (Exception ex)
            {
                resp.Mensagem = ex.Message;
                resp.Sucesso = false;
                throw;
            }
            return resp;
        }
    }
}
