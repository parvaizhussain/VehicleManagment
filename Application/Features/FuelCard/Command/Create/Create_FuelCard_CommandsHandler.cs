using Application.Contracts.IUOW;
using AutoMapper;
using MediatR;
using System.Data;

namespace Application.Features.FuelCard.Command.Create
{
    public class Create_FuelCard_CommandsHandler : IRequestHandler<Create_FuelCard_Commands, Create_FuelCard_CommandsResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Create_FuelCard_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
     
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Create_FuelCard_CommandsResponse> Handle(Create_FuelCard_Commands request, CancellationToken cancellationToken)
        {
            var createFuelCardCommandResponse = new Create_FuelCard_CommandsResponse();

            var validator = new Create_FuelCard_CommandsValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createFuelCardCommandResponse.Success = false;
                createFuelCardCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createFuelCardCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createFuelCardCommandResponse.Success)
            {
                var Fuelcard = _mapper.Map<Domain.Entities.FuelCard>(request);
                Fuelcard = await _unitOfWork.FuelCard.AddAsync(Fuelcard);
                Fuelcard = (Domain.Entities.FuelCard)await _unitOfWork.Commit(Fuelcard, "Insert", "FuelCard");
                createFuelCardCommandResponse._FuelCard_Dto = _mapper.Map<Create_FuelCard_Dto>(Fuelcard);
            }

            return createFuelCardCommandResponse;
        }

    }
}
