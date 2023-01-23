using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.Department.Queries.GetDepartmentByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Department.Queries.GetDepartmentByShortName
{
    public class GetDepartmentByShortNameQueryHandler : IRequestHandler<GetDepartmentByShortNameQuery, GetDepartmentVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDepartmentByShortNameQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetDepartmentVM> Handle(GetDepartmentByShortNameQuery request, CancellationToken cancellationToken)
        {
            var model = (await _unitOfWork.Department.ListAllAsync()).Where(x=>x.NormalizedName == request.ShortName).FirstOrDefault();
            var DepartmentDto = _mapper.Map<GetDepartmentVM>(model);

            return DepartmentDto;
        }
    }
}
