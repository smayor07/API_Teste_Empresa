using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.ViewModels
{
    public class AdministradorViewModel
    {
        public int AdministradorId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
    }
}
