using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Application.Commands.Filmes;
using Core.Bus;
using Entity.Entities;
using Entity.Enum;
using Entity.Interfaces.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeApplication _filmeApplication;
        private readonly IMediatorHandler _mediatorHandler;
        public FilmeController(IFilmeApplication filmeApplication, IMediatorHandler mediatorHandler)
        {
            _filmeApplication = filmeApplication;
            _mediatorHandler = mediatorHandler;
        }

        [HttpPost]
        [Route("CadastrarFilme")]
        public BaseResponse CadastrarFilme(string nome, string genero, string diretor)
        {
            var resp = new BaseResponse();

            //try
            //{
            //    Filme filme = new Filme()
            //    {
            //        Nome = nome,
            //        Genero = genero,
            //        Diretor = diretor,
            //        Votos = 0
            //    };

            //    _filmeApplication.CadastrarFilme(filme);

            //    var obj = new
            //    {
            //        Filme = filme
            //    };

            //    resp.Valor = obj;
            //    resp.Mensagem = "Filme cadastrado com sucesso!";
            //    resp.Sucesso = true;
            //}
            //catch (Exception ex)
            //{
            //    resp.Mensagem = ex.Message;
            //    resp.Sucesso = false;
            //    throw;
            //}
            return resp;
        }

        [HttpPut]
        [Route("VotarFilme")]
        public BaseResponse VotarFilme(int id, VotoEnum voto)
        {
            var resp = new BaseResponse();

            try
            {
                var command = new VotarFilmeCommand(id, (int)voto);
                _mediatorHandler.EnviarComando(command);
                _filmeApplication.Dispose();

                resp.Mensagem = "Filme votado com sucesso!";
                resp.Sucesso = true;
            }
            catch (Exception ex)
            {
                resp.Mensagem = ex.Message;
                resp.Sucesso = false;
                throw;
            }

            //try
            //{
            //    var filme = _filmeApplication.ObterFilmePorId(id);

            //    if (filme != null)
            //    {
            //        filme.Votos += (int)voto;

            //        _filmeApplication.GravarVoto(filme);

            //        var obj = new
            //        {
            //            Filme = filme
            //        };

            //        resp.Valor = obj;
            //        resp.Mensagem = "Filme votado com sucesso!";
            //        resp.Sucesso = true;
            //    }
            //    else
            //    {
            //        resp.Mensagem = "Nenhum filme encontrado!";
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

        [HttpGet]
        [Route("BuscarFilme")]
        public BaseResponse BuscarFilmes(FiltroBusca filtro, string nome = null, string genero = null, string diretor = null)
        {
            var resp = new BaseResponse();

            //try
            //{
            //    List<Filme> filmes = new List<Filme>();

            //    //0 => Nome, 1 => Genero, 2=> Diretor
            //    switch (filtro)
            //    {
            //        case FiltroBusca.Nome:
            //            if (nome != null)
            //            {
            //                filmes = _filmeApplication.BuscarFilmePorNome(nome);

            //                if (filmes.Count > 0)
            //                {
            //                    var obj = new
            //                    {
            //                        Filme = filmes
            //                    };

            //                    resp.Valor = obj;
            //                    resp.Mensagem = $"A consulta retornou {filmes.Count} resultados";
            //                    resp.Sucesso = true;
            //                }
            //                else
            //                {
            //                    resp.Mensagem = "Nenhum filme foi encontrado!";
            //                    resp.Sucesso = false;
            //                }
            //            }
            //            else
            //            {
            //                resp.Mensagem = "É necessario um nome para efetuar a busca!";
            //                resp.Sucesso = false;
            //            }
            //            break;
            //        case FiltroBusca.Genero:
            //            if (genero != null)
            //            {
            //                filmes = _filmeApplication.BuscarFilmePorGenero(genero);

            //                if (filmes.Count > 0)
            //                {
            //                    var obj = new
            //                    {
            //                        Filme = filmes
            //                    };

            //                    resp.Valor = obj;
            //                    resp.Mensagem = $"A consulta retornou {filmes.Count} resultados";
            //                    resp.Sucesso = true;
            //                }
            //                else
            //                {
            //                    resp.Mensagem = "Nenhum filme foi encontrado!";
            //                    resp.Sucesso = false;
            //                }
            //            }
            //            else
            //            {
            //                resp.Mensagem = "É necessario um genero para efetuar a busca!";
            //                resp.Sucesso = false;
            //            }
            //            break;
            //        case FiltroBusca.Diretor:
            //            if (diretor != null)
            //            {
            //                filmes = _filmeApplication.BuscarFilmePorDiretor(diretor);

            //                if (filmes.Count > 0)
            //                {
            //                    var obj = new
            //                    {
            //                        Filme = filmes
            //                    };

            //                    resp.Valor = obj;
            //                    resp.Mensagem = $"A consulta retornou {filmes.Count} resultados";
            //                    resp.Sucesso = true;
            //                }
            //                else
            //                {
            //                    resp.Mensagem = "Nenhum filme foi encontrado!";
            //                    resp.Sucesso = false;
            //                }
            //            }
            //            else
            //            {
            //                resp.Mensagem = "É necessario um diretor para efetuar a busca!";
            //                resp.Sucesso = false;
            //            }
            //            break;
            //        default:
            //            break;
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

        [HttpGet]
        [Route("DetalhesFilme")]
        public BaseResponse DetalhesFilmes(int id)
        {
            var resp = new BaseResponse();

            //try
            //{
            //    var filme = _filmeApplication.ObterFilmePorId(id);

            //    if (filme != null)
            //    {
            //        var obj = new
            //        {
            //            Filme = filme
            //        };
            //        resp.Valor = obj;
            //        resp.Mensagem = "Filme retornado com sucesso!";
            //        resp.Sucesso = true;
            //    }
            //    else
            //    {
            //        resp.Mensagem = "Nenhum filme foi encontrado!";
            //        resp.Sucesso = false;
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

        [HttpGet]
        [Route("ListarFilmesCadastrados")]
        public BaseResponse ListarFilme()
        {
            var resp = new BaseResponse();

            //try
            //{
            //    var filmes = _filmeApplication.BuscarTodosFilmes();

            //    if (filmes.Count > 0)
            //    {
            //        var obj = new
            //        {
            //            Filme = filmes
            //        };
            //        resp.Valor = obj;
            //        resp.Mensagem = $"Foram retornados {filmes.Count} resultados!";
            //        resp.Sucesso = true;
            //    }
            //    else
            //    {
            //        resp.Mensagem = "Nenhum filme foi encontrado!";
            //        resp.Sucesso = false;
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
    }
}
