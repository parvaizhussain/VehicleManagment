using AutoMapper;
using Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Contracts.IUOW;
namespace Application.Features.Group.Commands.CreateGroup
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, CreateGroupCommandResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGroupCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateGroupCommandResponse> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var createGroupCommandResponse = new CreateGroupCommandResponse();

            var validator = new CreateGroupCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createGroupCommandResponse.Success = false;
                createGroupCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createGroupCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createGroupCommandResponse.Success)
            {
                var Group = _mapper.Map<Domain.Entities.Group>(request);
                Group = await _unitOfWork.Group.AddAsync(Group);
                Group = (Domain.Entities.Group)await _unitOfWork.Commit(Group);
                createGroupCommandResponse.Group = _mapper.Map<CreateGroupDto>(Group);
            }

            return createGroupCommandResponse;
        }

    }
}
