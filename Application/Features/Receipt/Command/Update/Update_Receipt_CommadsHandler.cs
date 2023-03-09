using Application.Contracts.IUOW;
using Application.Exceptions;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Receipt.Command.Update
{
    public class Update_Receipt_CommadsHandler : IRequestHandler<Update_Receipt_Commads>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Update_Receipt_CommadsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Update_Receipt_Commads request, CancellationToken cancellationToken)
        {

            var VehicleBrandToUpdate = await _unitOfWork.Receipt.GetByIdAsync(request.ReceiptId);

            if (VehicleBrandToUpdate == null)
            {
                throw new NotFoundException(nameof(Receipt), request.ReceiptId);
            }

            var validator = new Update_Receipt_CommadsValidators();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, VehicleBrandToUpdate, typeof(Update_Receipt_Commads), typeof(Domain.Entities.Receipt));

            await _unitOfWork.Receipt.UpdateAsync(VehicleBrandToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}