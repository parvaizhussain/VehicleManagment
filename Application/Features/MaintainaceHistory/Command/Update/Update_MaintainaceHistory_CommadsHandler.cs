using Application.Contracts.IUOW;
using Application.Exceptions;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintainaceHistory.Command.Update
{
    public class Update_MaintainaceHistory_CommadsHandler : IRequestHandler<Update_MaintainaceHistory_Commads>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Update_MaintainaceHistory_CommadsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Update_MaintainaceHistory_Commads request, CancellationToken cancellationToken)
        {

            var MaintainaceHistoryToUpdate = await _unitOfWork.MaintainaceHistory.GetByIdAsync(request.MaintainaceHistoryId);

            if (MaintainaceHistoryToUpdate == null)
            {
                throw new NotFoundException(nameof(MaintainaceHistory), request.MaintainaceHistoryId);
            }

            var validator = new Update_MaintainaceHistory_CommadsValidators();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, MaintainaceHistoryToUpdate, typeof(Update_MaintainaceHistory_Commads), typeof(Domain.Entities.MaintainaceHistory));

            await _unitOfWork.MaintainaceHistory.UpdateAsync(MaintainaceHistoryToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}