using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class BaseResponse
    {
        public BaseResponse() { }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Valor { get; set; }
    }
}
