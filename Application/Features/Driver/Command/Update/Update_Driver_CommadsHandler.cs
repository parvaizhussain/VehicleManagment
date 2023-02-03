using Application.Contracts.IUOW;
using Application.Exceptions;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Driver.Command.Update
{
    public class Update_Driver_CommadsHandler : IRequestHandler<Update_Driver_Commads>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Update_Driver_CommadsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Update_Driver_Commads request, CancellationToken cancellationToken)
        {

            var DriverToUpdate = await _unitOfWork.Driver.GetByIdAsync(request.DriverID);

            if (DriverToUpdate == null)
            {
                throw new NotFoundException(nameof(Driver), request.DriverID);
            }

            var validator = new Update_Driver_CommadsValidators();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, DriverToUpdate, typeof(Update_Driver_Commads), typeof(Domain.Entities.Driver));

            await _unitOfWork.Driver.UpdateAsync(DriverToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}