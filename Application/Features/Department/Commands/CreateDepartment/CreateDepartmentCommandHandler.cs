using AutoMapper;
using Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Contracts.IUOW;
namespace Application.Features.Department.Commands.CreateDepartment
{
    public class CreateConcessionApplicationCommandHandler : IRequestHandler<CreateDepartmentCommand, CreateDepartmentCommandResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateConcessionApplicationCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateDepartmentCommandResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var createDepartmentCommandResponse = new CreateDepartmentCommandResponse();

            var validator = new CreateDepartmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createDepartmentCommandResponse.Success = false;
                createDepartmentCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createDepartmentCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createDepartmentCommandResponse.Success)
            {
                var Department = _mapper.Map<Domain.Entities.Department>(request);
                Department = await _unitOfWork.Department.AddAsync(Department);
                Department = (Domain.Entities.Department)await _unitOfWork.Commit(Department);
                createDepartmentCommandResponse.Department = _mapper.Map<CreateDepartmentDto>(Department);
            }

            return createDepartmentCommandResponse;
        }

    }
}
