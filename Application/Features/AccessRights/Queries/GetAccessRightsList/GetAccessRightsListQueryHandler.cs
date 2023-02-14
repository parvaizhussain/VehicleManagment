using Application.Contracts.IUOW;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.AccessRights.Queries.GetAccessRightsList
{
    public class GetAccessRightsListQueryHandler : IRequestHandler<GetAccessRightsListQuery, List<GetAccessRightsListVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAccessRightsListQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAccessRightsListVM>> Handle(GetAccessRightsListQuery request, CancellationToken cancellationToken)
        {
            var allAccessRights = (await _unitOfWork.AccessRights.ListAllAsync());
            return _mapper.Map<List<GetAccessRightsListVM>>(allAccessRights.Where(x=>x.IsDeleted == false));
        }
    }
}
