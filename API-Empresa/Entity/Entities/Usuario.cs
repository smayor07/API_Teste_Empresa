using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    public class Usuario : IAggregateRoot
    {
        public int UsuarioId { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }

        protected Usuario() { }

        public Usuario(string _nome, string _endereco, string _email)
        {
            Nome = _nome;
            Endereco = _endereco;
            Email = _email;
            Ativo = true;

            Validar();
        }

        public void InativarUsuario() => Ativo = false;

        public void EditarUsuario(int usuarioId ,string _nome, string _endereco, string _email)
        {
            UsuarioId = usuarioId;
            Nome = _nome;
            Endereco = _endereco;
            Email = _email;
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(UsuarioId.ToString(), "O id do usuario não pode estar vazio");
            Validacoes.ValidarSeVazio(Nome, "O nome do filme não pode estar vazio");
            Validacoes.ValidarSeVazio(Endereco, "O endereco não pode estar vazio");
            Validacoes.ValidarSeVazio(Email, "O email não pode estar vazio");
        }
    }
}
