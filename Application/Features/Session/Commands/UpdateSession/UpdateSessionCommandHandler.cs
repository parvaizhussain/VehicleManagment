using Application.Contracts.IUOW;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Session.Commands.UpdateSession
{
    public class UpdateSessionCommandHandler : IRequestHandler<UpdateSessionCommand>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSessionCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateSessionCommand request, CancellationToken cancellationToken)
        {

            var EmployeesToUpdate = await _unitOfWork.Session.GetByIdAsync(request.SessionID);

            if (EmployeesToUpdate == null)
            {
                throw new NotFoundException(nameof(Session), request.SessionID);
            }

            //  var validator = new UpdateConcessionsCommandValidator();
            //  var validationResult = await validator.ValidateAsync(request);

            ///if (validationResult.Errors.Count > 0)
            //    throw new ValidationException(validationResult);

            _mapper.Map(request, EmployeesToUpdate, typeof(UpdateSessionCommand), typeof(Domain.Entities.Session));

            await _unitOfWork.Session.UpdateAsync(EmployeesToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}