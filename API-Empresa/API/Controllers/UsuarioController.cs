using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Application.Commands.Usuarios;
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
        private readonly IUsuarioApplication _usuarioApplication;
        private readonly IMediatorHandler _mediatorHandler;

        public UsuarioController(IUsuarioApplication usuarioApplication, IMediatorHandler mediatorHandler)
        {
            _usuarioApplication = usuarioApplication;
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet]
        [Route("ListarUsuarios")]
        public BaseResponse ListarUsuarios()
        {
            var resp = new BaseResponse();

            try
            {
                var usuarios = _usuarioApplication.ObterUsuariosCadastrados();

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

            //try
            //{
            //    var usuario = _usuarioApplication.ObterUsuarioPorId(id);

            //    if (usuario != null)
            //    {
            //        usuario.UsuarioId = id;
            //        usuario.Nome = nome != null ? nome : usuario.Nome;
            //        usuario.Endereco = endereco != null ? endereco : usuario.Endereco;
            //        usuario.Email = email != null ? email : usuario.Email;

            //        _usuarioApplication.EditarUsuario(usuario);

            //        var obj = new
            //        {
            //            User = usuario
            //        };

            //        resp.Valor = obj;
            //        resp.Mensagem = "Usuário editado com sucesso!";
            //        resp.Sucesso = true;
            //    }
            //    else
            //    {
            //        resp.Mensagem = "Nenhum usuário encontrado!";
            //        resp.Sucesso = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    resp.Mensagem = ex.Message;
            //    resp.Sucesso = false;
            //    throw;
            //}
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
