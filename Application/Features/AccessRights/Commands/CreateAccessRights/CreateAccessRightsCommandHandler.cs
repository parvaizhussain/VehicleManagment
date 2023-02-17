using AutoMapper;
using Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Contracts.IUOW;
namespace Application.Features.AccessRights.Commands.CreateAccessRights
{
    public class CreateConcessionApplicationCommandHandler : IRequestHandler<CreateAccessRightsCommand, CreateAccessRightsCommandResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateConcessionApplicationCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateAccessRightsCommandResponse> Handle(CreateAccessRightsCommand request, CancellationToken cancellationToken)
        {
            var createAccessRightsCommandResponse = new CreateAccessRightsCommandResponse();

            var validator = new CreateAccessRightsCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createAccessRightsCommandResponse.Success = false;
                createAccessRightsCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createAccessRightsCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createAccessRightsCommandResponse.Success)
            {
                var AccessRights = _mapper.Map<Domain.Entities.AccessRights>(request);
                AccessRights.IsActive = true;
                AccessRights = await _unitOfWork.AccessRights.AddAsync(AccessRights);
                AccessRights = (Domain.Entities.AccessRights)await _unitOfWork.Commit(AccessRights);
                createAccessRightsCommandResponse.AccessRights = _mapper.Map<CreateAccessRightsDto>(AccessRights);
            }

            return createAccessRightsCommandResponse;
        }

    }
}
