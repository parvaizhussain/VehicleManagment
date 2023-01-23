using Application.Contracts.IUOW;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Group.Queries.GetGroupList
{
    public class GetGroupListQueryHandler : IRequestHandler<GetGroupListQuery, List<GetGroupListVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGroupListQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetGroupListVM>> Handle(GetGroupListQuery request, CancellationToken cancellationToken)
        {
            var allGroup = (await _unitOfWork.Group.GetAll(null,null,"Department"));
            return _mapper.Map<List<GetGroupListVM>>(allGroup);
        }
    }
}
