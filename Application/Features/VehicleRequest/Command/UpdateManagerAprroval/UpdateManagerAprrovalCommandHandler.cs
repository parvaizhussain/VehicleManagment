using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.VehicleRequest.Command.Update;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleRequest.Command.UpdateManagerAprroval
{
    public class UpdateManagerAprrovalCommandHandler : IRequestHandler<UpdateManagerAprrovalCommands>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateManagerAprrovalCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateManagerAprrovalCommands request, CancellationToken cancellationToken)
        {

            var VehicleRequestToUpdate = await _unitOfWork.VehicleRequest.GetByIdAsync(request.RequestID);

            if (VehicleRequestToUpdate == null)
            {
                throw new NotFoundException(nameof(VehicleRequest), request.RequestID);
            }

            var validator = new UpdateManagerAprrovalCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, VehicleRequestToUpdate, typeof(Update_VehicleRequest_Commads), typeof(Domain.Entities.VehicleRequest));

            await _unitOfWork.VehicleRequest.UpdateAsync(VehicleRequestToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}