using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBus
{
    public class MessageBus : IMessageBus
    {
        private IBus _bus;
    }
}
