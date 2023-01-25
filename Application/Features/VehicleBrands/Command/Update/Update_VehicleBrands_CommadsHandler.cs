using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.VehicleBrands.Command.Update;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleBrands.Command.Update
{
    public class Update_VehicleBrands_CommadsHandler : IRequestHandler<Update_VehicleBrands_Commads>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Update_VehicleBrands_CommadsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Update_VehicleBrands_Commads request, CancellationToken cancellationToken)
        {

            var VehicleBrandToUpdate = await _unitOfWork.VehicleBrands.GetByIdAsync(request.VehicleBrandId);

            if (VehicleBrandToUpdate == null)
            {
                throw new NotFoundException(nameof(VehicleBrands), request.VehicleBrandId);
            }

            var validator = new Update_VehicleBrands_CommadsValidators();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, VehicleBrandToUpdate, typeof(Update_VehicleBrands_Commads), typeof(Domain.Entities.VehicleBrands));

            await _unitOfWork.VehicleBrands.UpdateAsync(VehicleBrandToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}