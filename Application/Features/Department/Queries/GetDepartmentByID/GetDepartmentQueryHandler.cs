using Application.Contracts.IUOW;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Department.Queries.GetDepartmentByID
{
    public class GetDepartmentByIDQueryHandler : IRequestHandler<GetDepartmentQuery, GetDepartmentVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDepartmentByIDQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetDepartmentVM> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.Department.GetByIdAsync(request.DepartmentId);
            var DepartmentDto = _mapper.Map<GetDepartmentVM>(model);

            return DepartmentDto;
        }
    }
}
