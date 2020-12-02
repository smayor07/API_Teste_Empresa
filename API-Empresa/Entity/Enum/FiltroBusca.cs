using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entity.Enum
{
    public enum FiltroBusca
    {
        [DescriptionAttribute("Busca por nome")]
        Nome,
        [DescriptionAttribute("Busca por genero")]
        Genero,
        [DescriptionAttribute("Busca por diretor")]
        Diretor
    }
}
