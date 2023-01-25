using Application.Contracts.IUOW;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleBrands.Command.Create
{
    public class Create_VehicleBrands_CommandsHandler : IRequestHandler<Create_VehicleBrands_Commands, Create_VehicleBrands_CommandsResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Create_VehicleBrands_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Create_VehicleBrands_CommandsResponse> Handle(Create_VehicleBrands_Commands request, CancellationToken cancellationToken)
        {
            var createVehicleBrandCommandResponse = new Create_VehicleBrands_CommandsResponse();

            var validator = new Create_VehicleBrands_CommandsValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createVehicleBrandCommandResponse.Success = false;
                createVehicleBrandCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createVehicleBrandCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createVehicleBrandCommandResponse.Success)
            {
                var VehicleBrand = _mapper.Map<Domain.Entities.VehicleBrands>(request);
                VehicleBrand = await _unitOfWork.VehicleBrands.AddAsync(VehicleBrand);
                VehicleBrand = (Domain.Entities.VehicleBrands)await _unitOfWork.Commit(VehicleBrand, "Insert", "VehicleBrands");
                createVehicleBrandCommandResponse._VehicleBrands_Dto = _mapper.Map<Create_VehicleBrands_Dto>(VehicleBrand);
            }

            return createVehicleBrandCommandResponse;
        }

    }
}
