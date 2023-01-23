using AutoMapper;
using Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Contracts.IUOW;
namespace Application.Features.Network.Commands.CreateNetwork
{
    public class CreateConcessionApplicationCommandHandler : IRequestHandler<CreateNetworkCommand, CreateNetworkCommandResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateConcessionApplicationCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateNetworkCommandResponse> Handle(CreateNetworkCommand request, CancellationToken cancellationToken)
        {
            var createNetworkCommandResponse = new CreateNetworkCommandResponse();

            var validator = new CreateNetworkCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createNetworkCommandResponse.Success = false;
                createNetworkCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createNetworkCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createNetworkCommandResponse.Success)
            {
                var Network = _mapper.Map<Domain.Entities.Network>(request);
                Network = await _unitOfWork.Network.AddAsync(Network);
                Network = (Domain.Entities.Network)await _unitOfWork.Commit(Network);
                createNetworkCommandResponse.Network = _mapper.Map<CreateNetworkDto>(Network);
            }

            return createNetworkCommandResponse;
        }

    }
}
