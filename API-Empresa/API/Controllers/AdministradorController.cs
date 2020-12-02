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
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorApplication _administradorApplication;

        public AdministradorController(IAdministradorApplication administradorApplication)
        {
            _administradorApplication = administradorApplication;
        }

        [HttpGet]
        [Route("ListarAdministradores")]
        public BaseResponse ListarAdministradores()
        {
            var resp = new BaseResponse();

            try
            {
                var administradores = _administradorApplication.ObterAdministradoresCadastrados();

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
                Administrador administrador = new Administrador
                {
                    Nome = nome,
                    Endereco = endereco,
                    Email = email,
                    Ativo = true
                };

                _administradorApplication.CadastrarAdministrador(administrador);

                var obj = new
                {
                    Adm = administrador
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
                var usuarios = _administradorApplication.ObterUsuariosAtivos();

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
                var administrador = _administradorApplication.ObterAdministradorPorId(id);

                if (administrador != null)
                {
                    administrador.AdministradorId = id;
                    administrador.Nome = nome != null ? nome : administrador.Nome;
                    administrador.Endereco = endereco != null ? endereco : administrador.Endereco;
                    administrador.Email = email != null ? email : administrador.Email;

                    _administradorApplication.EditarAdministrador(administrador);

                    var obj = new
                    {
                        Adm = administrador
                    };

                    resp.Valor = obj;
                    resp.Mensagem = "Administrador editado com sucesso!";
                    resp.Sucesso = true;
                }
                else
                {
                    resp.Mensagem = "Nenhum administrador encontrado!";
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
        [Route("ExcluirAdministrador")]
        public BaseResponse ExcluirAdministrador(int id)
        {
            var resp = new BaseResponse();
            try
            {
                var administrador = _administradorApplication.ObterAdministradorPorId(id);

                if (administrador != null)
                {
                    administrador.AdministradorId = id;
                    administrador.Ativo = false;

                    _administradorApplication.ExcluirAdministrador(administrador);

                    var obj = new
                    {
                        Adm = administrador
                    };

                    resp.Valor = obj;
                    resp.Mensagem = "Administrador excluído com sucesso!";
                    resp.Sucesso = true;
                }
                else
                {
                    resp.Mensagem = "Nenhum administrador encontrado!";
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
