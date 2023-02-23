using Application.Contracts.IUOW;
using Application.Exceptions;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceCenter.Command.Update
{
    public class Update_ServiceCenter_CommadsHandler : IRequestHandler<Update_ServiceCenter_Commads>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Update_ServiceCenter_CommadsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Update_ServiceCenter_Commads request, CancellationToken cancellationToken)
        {

            var VehicleBrandToUpdate = await _unitOfWork.ServiceCenter.GetByIdAsync(request.ServiceCenterId);

            if (VehicleBrandToUpdate == null)
            {
                throw new NotFoundException(nameof(ServiceCenter), request.ServiceCenterId);
            }

            var validator = new Update_ServiceCenter_CommadsValidators();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, VehicleBrandToUpdate, typeof(Update_ServiceCenter_Commads), typeof(Domain.Entities.ServiceCenter));

            VehicleBrandToUpdate.VehicleCompanyID = request.DealerID;
            await _unitOfWork.ServiceCenter.UpdateAsync(VehicleBrandToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}