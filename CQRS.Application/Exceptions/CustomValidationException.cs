using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Exceptions
{
    public class CustomValidationException: ApplicationException
    {
        public List<string> Errors { get; set; }

        public CustomValidationException(ValidationResult validationResult) 
        { 
            Errors = new List<string>();

            foreach (var error in validationResult.Errors) 
            {
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}
