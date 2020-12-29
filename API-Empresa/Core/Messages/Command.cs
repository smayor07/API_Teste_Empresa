using FluentValidation.Results;
using MediatR;
using System;

namespace Core
{
    public abstract class Command : IRequest<bool>
    {
        public DateTime Timestamp { get; set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
