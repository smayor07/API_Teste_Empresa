﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;

        Task<bool> EnviarComando<T>(T comando) where T : Command;
    }
}