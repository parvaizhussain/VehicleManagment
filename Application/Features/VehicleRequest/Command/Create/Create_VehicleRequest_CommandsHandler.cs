using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleRequest.Command.Create
{
    public class Create_VehicleRequest_CommandsHandler : IRequestHandler<Create_VehicleRequest_Commands, Create_VehicleRequest_CommandsResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Create_VehicleRequest_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Create_VehicleRequest_CommandsResponse> Handle(Create_VehicleRequest_Commands request, CancellationToken cancellationToken)
        {
            var createVehicleRequestCommandResponse = new Create_VehicleRequest_CommandsResponse();

            var validator = new Create_VehicleRequest_CommandsValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createVehicleRequestCommandResponse.Success = false;
                createVehicleRequestCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createVehicleRequestCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createVehicleRequestCommandResponse.Success)
            {
                var VehicleRequest = _mapper.Map<Domain.Entities.VehicleRequest>(request);
                VehicleRequest.IsActive = true; 
                VehicleRequest = await _unitOfWork.VehicleRequest.AddAsync(VehicleRequest);
                VehicleRequest = (Domain.Entities.VehicleRequest)await _unitOfWork.Commit(VehicleRequest, "Insert", "VehicleRequest");
                createVehicleRequestCommandResponse._VehicleRequest_Dto = _mapper.Map<Create_VehicleRequest_Dto>(VehicleRequest);
            }

            return createVehicleRequestCommandResponse;
        }

    }
}
