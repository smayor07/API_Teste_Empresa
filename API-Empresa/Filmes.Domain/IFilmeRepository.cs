﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Filmes.Domain
{
    public interface IFilmeRepository
    {
        void setVoto(VotoEnum voto);
    }
}
