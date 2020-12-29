using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public abstract class Event : INotification
    {
        public DateTime Timestamp { get; set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
