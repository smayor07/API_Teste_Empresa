using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
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

        public UsuarioController(IUsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
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
                Usuario usuario = new Usuario()
                {
                    Nome = nome,
                    Endereco = endereco,
                    Email = email,
                    Ativo = true
                };

                _usuarioApplication.CadastrarUsuario(usuario);

                var obj = new
                {
                    User = usuario
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
                var usuario = _usuarioApplication.ObterUsuarioPorId(id);

                if (usuario != null)
                {
                    usuario.UsuarioId = id;
                    usuario.Nome = nome != null ? nome : usuario.Nome;
                    usuario.Endereco = endereco != null ? endereco : usuario.Endereco;
                    usuario.Email = email != null ? email : usuario.Email;

                    _usuarioApplication.EditarUsuario(usuario);

                    var obj = new
                    {
                        User = usuario
                    };

                    resp.Valor = obj;
                    resp.Mensagem = "Usuário editado com sucesso!";
                    resp.Sucesso = true;
                }
                else
                {
                    resp.Mensagem = "Nenhum usuário encontrado!";
                    resp.Sucesso = true;
                }
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
                var usuario = _usuarioApplication.ObterUsuarioPorId(id);

                if (usuario != null)
                {
                    usuario.UsuarioId = id;
                    usuario.Ativo = false;

                    _usuarioApplication.ExcluirUsuario(usuario);

                    var obj = new
                    {
                        User = usuario
                    };

                    resp.Valor = obj;
                    resp.Mensagem = "Usuário excluído com sucesso!";
                    resp.Sucesso = true;
                }
                else
                {
                    resp.Mensagem = "Nenhum usuário encontrado!";
                    resp.Sucesso = true;
                }
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
