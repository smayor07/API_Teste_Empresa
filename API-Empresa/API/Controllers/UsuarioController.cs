using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Application.Commands.Usuarios;
using Application.Queries.Usuarios;
using Core.Bus;
using Entity.Entities;
using Entity.Interfaces.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IUsuarioQueries _usuarioQueries;

        public UsuarioController(IMediatorHandler mediatorHandler, IUsuarioQueries usuarioQueries)
        {
            _mediatorHandler = mediatorHandler;
            _usuarioQueries = usuarioQueries;
        }

        [HttpGet]
        [Route("ListarUsuarios")]
        public BaseResponse ListarUsuarios()
        {
            var resp = new BaseResponse();

            try
            {
                var usuarios = _usuarioQueries.ObterUsuariosCadastrados();

                var obj = new
                {
                    Adm = usuarios
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

        [HttpPost]
        [Route("CadastrarUsuario")]
        public BaseResponse CadastrarUsuario(string nome, string endereco, string email)
        {
            var resp = new BaseResponse();

            try
            {
                var command = new CadastrarUsuarioCommand(nome, endereco, email);
                _mediatorHandler.EnviarComando(command);

                var obj = new
                {
                    User = command
                };

                resp.Valor = obj;
                resp.Mensagem = "Usuário cadastrado com sucesso!";
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
        [Route("EditarUsuario")]
        public BaseResponse EditarUsuario(int id, string nome = null, string endereco = null, string email = null)
        {
            var resp = new BaseResponse();

            try
            {
                var command = new EditarUsuarioCommand(id, nome, endereco, email);
                _mediatorHandler.EnviarComando(command);

                var obj = new
                {
                    User = command
                };

                resp.Valor = obj;
                resp.Mensagem = "Usuário editado com sucesso!";
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
        [Route("ExcluirUsuario")]
        public BaseResponse ExcluirUsuario(int id)
        {
            var resp = new BaseResponse();
            try
            {
                var command = new InativarUsuarioCommand(id);
                _mediatorHandler.EnviarComando(command);

                var obj = new
                {
                    User = command
                };

                resp.Valor = obj;
                resp.Mensagem = "Usuário excluído com sucesso!";
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
