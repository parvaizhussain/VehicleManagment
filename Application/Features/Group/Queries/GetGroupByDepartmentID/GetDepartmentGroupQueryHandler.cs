using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.Group.Queries.GetGroupByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Group.Queries.GetDepartmentGroupByID
{
    public class GetDepartmentGroupByIDQueryHandler : IRequestHandler<GetDepartmentGroupQuery, List<GetGroupVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDepartmentGroupByIDQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetGroupVM>> Handle(GetDepartmentGroupQuery request, CancellationToken cancellationToken)
        {
            var model = (await _unitOfWork.Group.GetAll(x=>x.DepartmentId == request.DepartmentId, null, "Department"));
            var GroupDto = _mapper.Map<List<GetGroupVM>>(model);

            return GroupDto;
        }
    }
}
