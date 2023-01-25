using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.VehicleDetails.Command.Update;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleDetails.Command.Update
{
    public class Update_VehicleDetails_CommadsHandler : IRequestHandler<Update_VehicleDetails_Commads>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Update_VehicleDetails_CommadsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Update_VehicleDetails_Commads request, CancellationToken cancellationToken)
        {

            var VehicleDetailToUpdate = await _unitOfWork.VehicleDetails.GetByIdAsync(request.VehicleID);

            if (VehicleDetailToUpdate == null)
            {
                throw new NotFoundException(nameof(VehicleDetails), request.VehicleID);
            }

            var validator = new Update_VehicleDetails_CommadsValidators();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, VehicleDetailToUpdate, typeof(Update_VehicleDetails_Commads), typeof(Domain.Entities.Set_VehicleDetails));

            await _unitOfWork.VehicleDetails.UpdateAsync(VehicleDetailToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}