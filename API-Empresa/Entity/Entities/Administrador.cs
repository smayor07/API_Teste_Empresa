using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    public class Administrador : EntityBase
    {
        public int AdministradorId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
    }
}
