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

namespace Application.Features.Group.Queries.GetGroupByID
{
    public class GetGroupByIDQueryHandler : IRequestHandler<GetGroupQuery, GetGroupVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGroupByIDQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetGroupVM> Handle(GetGroupQuery request, CancellationToken cancellationToken)
        {
            var model = (await _unitOfWork.Group.GetAll(x=>x.GroupId == request.GroupId, null, "Department"));
            var GroupDto = _mapper.Map<GetGroupVM>(model.FirstOrDefault());

            return GroupDto;
        }
    }
}
