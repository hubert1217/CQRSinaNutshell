using AutoMapper;
using CQRS.Application.Contracts.Persistance;
using CQRS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Functions.Webinars.Commands.CreateWebinar
{
    public class CreateWebinarCommandHandler : IRequestHandler<CreateWebinarCommand, CreateWebinarCommandResponse>
    {

        private readonly IWebinarRepository _webinarRepository;
        private readonly IMapper _mapper;

        public CreateWebinarCommandHandler(IWebinarRepository webinarRepository, IMapper mapper)
        {
            _webinarRepository = webinarRepository;
            _mapper = mapper;
        }

        public async Task<CreateWebinarCommandResponse> Handle(CreateWebinarCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateWebinarCommandValidator();

            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
            {
                return new CreateWebinarCommandResponse(validatorResult);
            }


            var webinar = _mapper.Map<Webinar>(request);

            webinar = await _webinarRepository.AddAsync(webinar);

            return new CreateWebinarCommandResponse(webinar.Id);
        }
    }
}
