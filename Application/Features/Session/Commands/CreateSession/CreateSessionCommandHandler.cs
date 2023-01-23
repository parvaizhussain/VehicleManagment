using AutoMapper;
using Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Contracts.IUOW;

namespace Application.Features.Session.Commands.CreateSession
{
    public class CreateSessionCommandHandler : IRequestHandler<CreateSessionCommand, CreateSessionCommandResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSessionCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateSessionCommandResponse> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
        {
            var createEmployeeCommandResponse = new CreateSessionCommandResponse();

            var validator = new CreateSessionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createEmployeeCommandResponse.Success = false;
                createEmployeeCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createEmployeeCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createEmployeeCommandResponse.Success)
            {
                var Employee = _mapper.Map<Domain.Entities.Session>(request);
                Employee = await _unitOfWork.Session.AddAsync(Employee);
                // await _unitOfWork.Commit();
                Employee = (Domain.Entities.Session)await _unitOfWork.Commit(Employee);
                createEmployeeCommandResponse.SessionDto = _mapper.Map<CreateSessionDto>(Employee);
            }

            return createEmployeeCommandResponse;
        }

    }
}

