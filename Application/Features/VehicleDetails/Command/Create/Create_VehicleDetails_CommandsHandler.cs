using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleDetails.Command.Create
{
    public class Create_VehicleDetails_CommandsHandler : IRequestHandler<Create_VehicleDetails_Commands, Create_VehicleDetails_CommandsResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Create_VehicleDetails_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Create_VehicleDetails_CommandsResponse> Handle(Create_VehicleDetails_Commands request, CancellationToken cancellationToken)
        {
            var createVehicleDetailCommandResponse = new Create_VehicleDetails_CommandsResponse();

            var validator = new Create_VehicleDetails_CommandsValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createVehicleDetailCommandResponse.Success = false;
                createVehicleDetailCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createVehicleDetailCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createVehicleDetailCommandResponse.Success)
            {
                var VehicleDetail = _mapper.Map<Domain.Entities.Set_VehicleDetails>(request);
                VehicleDetail = await _unitOfWork.VehicleDetails.AddAsync(VehicleDetail);
                VehicleDetail = (Domain.Entities.Set_VehicleDetails)await _unitOfWork.Commit(VehicleDetail, "Insert", "VehicleDetails");
                createVehicleDetailCommandResponse._VehicleDetails_Dto = _mapper.Map<Create_VehicleDetails_Dto>(VehicleDetail);
            }

            return createVehicleDetailCommandResponse;
        }

    }
}
