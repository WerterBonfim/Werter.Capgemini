using System;
using FluentValidation.Results;

namespace Werter.Capgemini.WebApi.Core.Messages
{
    public abstract class Command : IRequest<ValidationResult>
    {
        public ValidationResult ValidationResult { get; set; }

        public virtual bool EValido()
        {
            throw new NotImplementedException();
        }
    }
}