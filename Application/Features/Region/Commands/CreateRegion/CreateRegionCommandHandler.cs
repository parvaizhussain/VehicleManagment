using AutoMapper;
using Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Contracts.IUOW;
namespace Application.Features.Region.Commands.CreateRegion
{
    public class CreateRegionCommandHandler : IRequestHandler<CreateRegionCommand, CreateRegionCommandResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRegionCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateRegionCommandResponse> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
        {
            var createRegionCommandResponse = new CreateRegionCommandResponse();

            var validator = new CreateRegionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createRegionCommandResponse.Success = false;
                createRegionCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createRegionCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createRegionCommandResponse.Success)
            {
                var Region = _mapper.Map<Domain.Entities.Region>(request);
                Region.IsActive=true;
                Region = await _unitOfWork.Region.AddAsync(Region);
                Region = (Domain.Entities.Region)await _unitOfWork.Commit(Region);
                createRegionCommandResponse.Region = _mapper.Map<CreateRegionDto>(Region);
            }

            return createRegionCommandResponse;
        }

    }
}
