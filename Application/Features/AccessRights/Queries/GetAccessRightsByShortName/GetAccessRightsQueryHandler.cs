using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.AccessRights.Queries.GetAccessRightsByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.AccessRights.Queries.GetAccessRightsByShortName
{
    public class GetAccessRightsByShortNameQueryHandler : IRequestHandler<GetAccessRightsByShortNameQuery, GetAccessRightsVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAccessRightsByShortNameQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAccessRightsVM> Handle(GetAccessRightsByShortNameQuery request, CancellationToken cancellationToken)
        {
            var model = (await _unitOfWork.AccessRights.ListAllAsync()).Where(x=>x.NormalizedName == request.ShortName).FirstOrDefault();
            var AccessRightsDto = _mapper.Map<GetAccessRightsVM>(model);

            return AccessRightsDto;
        }
    }
}
