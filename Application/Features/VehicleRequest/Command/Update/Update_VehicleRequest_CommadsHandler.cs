using Application.Contracts.IUOW;
using Application.Exceptions;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleRequest.Command.Update
{
    public class Update_VehicleRequest_CommadsHandler : IRequestHandler<Update_VehicleRequest_Commads>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Update_VehicleRequest_CommadsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Update_VehicleRequest_Commads request, CancellationToken cancellationToken)
        {

            var VehicleRequestToUpdate = await _unitOfWork.VehicleRequest.GetByIdAsync(request.RequestID);

            if (VehicleRequestToUpdate == null)
            {
                throw new NotFoundException(nameof(VehicleRequest), request.RequestID);
            }

            var validator = new Update_VehicleRequest_CommadsValidators();
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