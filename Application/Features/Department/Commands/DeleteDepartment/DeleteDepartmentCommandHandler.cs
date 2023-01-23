using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.Department.Queries.GetDepartmentByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, GetDepartmentVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDepartmentCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetDepartmentVM> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {

            var DepartmentToUpdate =  await _unitOfWork.Department.GetByIdAsync(request.DepartmentId);
            if(DepartmentToUpdate.IsDeleted)
                DepartmentToUpdate.IsDeleted = false;
            else
                DepartmentToUpdate.IsDeleted = true;
            await _unitOfWork.Department.UpdateAsync(DepartmentToUpdate);
            await _unitOfWork.Commit();

            var DepartmentDto = _mapper.Map<GetDepartmentVM>(DepartmentToUpdate);

            return DepartmentDto;
        }
    }
}