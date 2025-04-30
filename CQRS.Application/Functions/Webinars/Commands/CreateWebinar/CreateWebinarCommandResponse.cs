using CQRS.Application.Responses;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Functions.Webinars.Commands.CreateWebinar
{
    public class CreateWebinarCommandResponse : BaseResponse
    {
        public int? Id { get; set; }

        public CreateWebinarCommandResponse() : base()
        { }

        public CreateWebinarCommandResponse(string? message = null) : base(message)
        {
        }

        public CreateWebinarCommandResponse(string message, bool success) : base(message, success)
        {
        }

        public CreateWebinarCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
        }

        public CreateWebinarCommandResponse(int webinarId)
        {
            Id = webinarId;
        }
    }
}
