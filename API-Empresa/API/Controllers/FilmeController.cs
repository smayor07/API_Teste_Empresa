using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using API.Models;
using Application.Commands.Filmes;
using Application.Queries.Filmes;
using Core.Bus;
using Core.Integration;
using Core.Integration.Filmes;
using Entity.Entities;
using Entity.Enum;
using MessageBus;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IFilmeQueries _filmeQueries;
        private readonly IMessageBus _messageBus;
        public FilmeController(IMediatorHandler mediatorHandler, IFilmeQueries filmeQueries, IMessageBus messageBus)
        {
            _mediatorHandler = mediatorHandler;
            _filmeQueries = filmeQueries;
            _messageBus = messageBus;
        }

        [HttpPost]
        [Route("CadastrarFilme")]
        public BaseResponse CadastrarFilme(string nome, string genero, string diretor)
        {
            var resp = new BaseResponse();

            try
            {
                var command = new CadastrarFilmeCommand(nome, genero, diretor);
                _mediatorHandler.EnviarComando(command);

                var obj = new
                {
                    Filme = command
                };

                resp.Valor = obj;
                resp.Mensagem = "Filme cadastrado com sucesso!";
                resp.Sucesso = true;

            }
            catch (Exception ex)
            {
                resp.Mensagem = ex.Message;
                resp.Sucesso = false;
            }
            return resp;
        }

        [HttpPut]
        [Route("VotarFilme")]
        public BaseResponse VotarFilme(int id, VotoEnum voto)
        {
            var resp = new BaseResponse();

            try
            {
                var votoFilmeIntegration = new VotoFilmeIntegrationEvent(id, (int) voto);
                var filmeResult = RegistrarVoto(votoFilmeIntegration);

                if (!filmeResult.Result.ValidationResult.IsValid)
                {
                    resp.Valor = filmeResult;
                    resp.Mensagem = "Ocorreu um erro ao efetuar o voto!";
                    resp.Sucesso = false;
                }
                else
                {
                    resp.Valor = filmeResult;
                    resp.Mensagem = "Filme votado com sucesso!";
                    resp.Sucesso = true;
                }

                //var command = new VotarFilmeCommand(id, (int)voto);
                //_mediatorHandler.EnviarComando(command);
                
            }
            catch (Exception ex)
            {
                resp.Mensagem = ex.Message;
                resp.Sucesso = false;
            }
            return resp;
        }

        [HttpGet]
        [Route("BuscarFilme")]
        public BaseResponse BuscarFilmes(FiltroBusca filtro, string nome = null, string genero = null, string diretor = null)
        {
            var resp = new BaseResponse();

            try
            {
                //0 => Nome, 1 => Genero, 2 => Diretor
                switch (filtro)
                {
                    case FiltroBusca.Nome:
                        if (nome != null)
                        {
                            var filmes = _filmeQueries.BuscarFilmePorNome(nome);

                            var obj = new
                            {
                                Filme = filmes
                            };

                            resp.Valor = obj;
                            resp.Mensagem = $"A consulta retornou {filmes.Count} resultados";
                            resp.Sucesso = true;
                        }
                        else
                        {
                            resp.Mensagem = "É necessario um nome para efetuar a busca!";
                            resp.Sucesso = false;
                        }
                        break;
                    case FiltroBusca.Genero:
                        if (genero != null)
                        {
                            var filmes = _filmeQueries.BuscarFilmePorGenero(genero);

                            var obj = new
                            {
                                Filme = filmes
                            };

                            resp.Valor = obj;
                            resp.Mensagem = $"A consulta retornou {filmes.Count} resultados";
                            resp.Sucesso = true;
                        }
                        else
                        {
                            resp.Mensagem = "É necessario um genero para efetuar a busca!";
                            resp.Sucesso = false;
                        }
                        break;
                    case FiltroBusca.Diretor:
                        if (diretor != null)
                        {
                            var filmes = _filmeQueries.BuscarFilmePorDiretor(diretor);

                            var obj = new
                            {
                                Filme = filmes
                            };

                            resp.Valor = obj;
                            resp.Mensagem = $"A consulta retornou {filmes.Count} resultados";
                            resp.Sucesso = true;
                        }
                        else
                        {
                            resp.Mensagem = "É necessario um diretor para efetuar a busca!";
                            resp.Sucesso = false;
                        }
                        break;
                    default:
                        break;
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

        [HttpGet]
        [Route("DetalhesFilme")]
        public BaseResponse DetalhesFilmes(int id)
        {
            var resp = new BaseResponse();

            try
            {
                var filme = _filmeQueries.ObterFilmePorId(id);

                if (filme != null)
                {
                    var obj = new
                    {
                        Filme = filme
                    };
                    resp.Valor = obj;
                    resp.Mensagem = "Filme retornado com sucesso!";
                    resp.Sucesso = true;
                }
                else
                {
                    resp.Mensagem = "Nenhum filme foi encontrado!";
                    resp.Sucesso = false;
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

        [HttpGet]
        [Route("ListarFilmesCadastrados")]
        public BaseResponse ListarFilme()
        {
            var resp = new BaseResponse();

            try
            {
                var filmes = _filmeQueries.BuscarTodosFilmes();

                var obj = new
                {
                    Filme = filmes
                };
                resp.Valor = obj;
                resp.Mensagem = $"Foram retornados {filmes.Count} resultados!";
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

        private async Task<ResponseMessage> RegistrarVoto(VotoFilmeIntegrationEvent votoFilmeIntegration)
        {
            var filmeBd = _filmeQueries.ObterFilmePorId(votoFilmeIntegration.FilmeId);

            var filmeVotado = new VotoFilmeIntegrationEvent(filmeBd.FilmeId, votoFilmeIntegration.Votos);

            return await _messageBus.RequestAsync<VotoFilmeIntegrationEvent, ResponseMessage>(filmeVotado);
        }
    }
}
