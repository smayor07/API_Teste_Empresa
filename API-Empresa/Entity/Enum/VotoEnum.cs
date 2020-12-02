using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entity.Enum
{
    public enum VotoEnum
    {
        [DescriptionAttribute("Zero Estrelas")]
        Zero = 0,
        [DescriptionAttribute("Uma Estrela")]
        Um = 1,
        [DescriptionAttribute("Duas Estrelas")]
        Dois = 2,
        [DescriptionAttribute("Três Estrelas")]
        Tres = 3,
        [DescriptionAttribute("Quatro Estrelas")]
        Quatro = 4,
    }
}
