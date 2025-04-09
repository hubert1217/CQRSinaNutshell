using CQRS.Application.Responses;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Functions.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public int? CategoryId { get; set; }

        public CreateCategoryCommandResponse()
        {
        }

        public CreateCategoryCommandResponse(string? message = null) : base(message)
        {
        }

        public CreateCategoryCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
        }

        public CreateCategoryCommandResponse(string message, bool success) : base(message, success)
        {

        }

        public CreateCategoryCommandResponse(int id)
        {
            CategoryId = id;
        }
    }
}
