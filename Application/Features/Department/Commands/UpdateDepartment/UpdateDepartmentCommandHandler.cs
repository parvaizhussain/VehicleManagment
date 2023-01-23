using Application.Contracts.IUOW;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Department.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDepartmentCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {

            var DepartmentToUpdate = await _unitOfWork.Department.GetByIdAsync(request.DepartmentId);

            if (DepartmentToUpdate == null)
            {
                throw new NotFoundException(nameof(Department), request.DepartmentId);
            }

            var validator = new UpdateDepartmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, DepartmentToUpdate, typeof(UpdateDepartmentCommand), typeof(Domain.Entities.Department));

            await _unitOfWork.Department.UpdateAsync(DepartmentToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}