using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.ServiceCenter.Command.Update;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FuelCard.Command.Update
{
    public class Update_FuelCard_CommandsHandler : IRequestHandler<Update_FuelCard_Commands>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Update_FuelCard_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Update_FuelCard_Commands request, CancellationToken cancellationToken)
        {

            var FuelCardToUpdate = await _unitOfWork.FuelCard.GetByIdAsync(request.CardID);

            if (FuelCardToUpdate == null)
            {
                throw new NotFoundException(nameof(FuelCard), request.CardID);
            }

            var validator = new Update_FuelCard_CommandsValidators();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, FuelCardToUpdate, typeof(Update_FuelCard_Commands), typeof(Domain.Entities.FuelCard));

            await _unitOfWork.FuelCard.UpdateAsync(FuelCardToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}