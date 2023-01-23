using Application.Contracts.IUOW;
using Application.Features.Vehicle.Command.CreateVehicle;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Vehicle.Command.CreateCommand
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, CreateVehicleCommandReponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateVehicleCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateVehicleCommandReponse> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var createVehicleCommandResponse = new CreateVehicleCommandReponse();

            var validator = new CreateVehicleCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createVehicleCommandResponse.Success = false;
                createVehicleCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createVehicleCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createVehicleCommandResponse.Success)
            {
                var Vehicle = _mapper.Map<Domain.Entities.VehicleSpecification>(request);
                Vehicle = await _unitOfWork.Vehicle.AddAsync(Vehicle);
                Vehicle = (Domain.Entities.VehicleSpecification)await _unitOfWork.Commit(Vehicle, "Insert", "Vehicle");
                createVehicleCommandResponse.VehicleDto = _mapper.Map<CreateVehicleDto>(Vehicle);
            }

            return createVehicleCommandResponse;
        }

    }
}