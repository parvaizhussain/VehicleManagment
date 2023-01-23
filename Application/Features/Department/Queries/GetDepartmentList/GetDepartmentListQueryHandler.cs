using Application.Contracts.IUOW;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Department.Queries.GetDepartmentList
{
    public class GetDepartmentListQueryHandler : IRequestHandler<GetDepartmentListQuery, List<GetDepartmentListVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDepartmentListQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetDepartmentListVM>> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
        {
            var allDepartment = (await _unitOfWork.Department.ListAllAsync());
            return _mapper.Map<List<GetDepartmentListVM>>(allDepartment);
        }
    }
}
