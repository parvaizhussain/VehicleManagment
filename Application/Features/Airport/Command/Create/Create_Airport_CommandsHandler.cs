using AutoMapper;
using Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Contracts.IUOW;
using Application.Features.ServiceCenter.Command.Create;

namespace Application.Features.Airport.Command.Create
{
    public class Create_Airport_CommandsHandler : IRequestHandler<Create_Airport_Commands, Create_Airport_CommandsResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Create_Airport_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Create_Airport_CommandsResponse> Handle(Create_Airport_Commands request, CancellationToken cancellationToken)
        {
            var createAirportCommandResponse = new Create_Airport_CommandsResponse();

            var validator = new Create_Airport_CommandsValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createAirportCommandResponse.Success = false;
                createAirportCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createAirportCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createAirportCommandResponse.Success)
            {
                var Airport = _mapper.Map<Domain.Entities.Airport>(request);
                Airport.IsActive = true;
                Airport = await _unitOfWork.Airport.AddAsync(Airport);
                Airport = (Domain.Entities.Airport)await _unitOfWork.Commit(Airport, "Insert", "Airports");
                createAirportCommandResponse._Airport_Dto = _mapper.Map<Create_Airport_Dto>(Airport);
            }

            return createAirportCommandResponse;
        }

    }
}
