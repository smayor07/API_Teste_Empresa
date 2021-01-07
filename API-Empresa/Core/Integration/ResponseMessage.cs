using Core.Messages;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Integration
{
    public class ResponseMessage : Message
    {
        //public ValidationResult ValidationResult { get; set; }
        public bool ValidationResult { get; set; }

        public ResponseMessage(bool _validationResult)
        {
            ValidationResult = _validationResult;
        }
    }
}
