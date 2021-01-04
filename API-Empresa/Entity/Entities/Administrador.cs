using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    public class Administrador : IAggregateRoot
    {
        public int AdministradorId { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }

        protected Administrador() { }

        public Administrador(string _nome, string _endereco, string _email)
        {
            Nome = _nome;
            Endereco = _endereco;
            Email = _email;
            Ativo = true;

            Validar();
        }

        public void InativarAdministrador() => Ativo = false;

        public void EditarAdministrador(int administradorId, string _nome, string _endereco, string _email)
        {
            AdministradorId = administradorId;
            Nome = _nome;
            Endereco = _endereco;
            Email = _email;
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(AdministradorId.ToString(), "O id do usuario não pode estar vazio");
            Validacoes.ValidarSeVazio(Nome, "O nome não pode estar vazio");
            Validacoes.ValidarSeVazio(Endereco, "O endereco não pode estar vazio");
            Validacoes.ValidarSeVazio(Email, "O email não pode estar vazio");
        }
    }
}
