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

namespace Application.Features.AccessRights.Queries.GetAccessRightsByID
{
    public class GetAccessRightsByIDQueryHandler : IRequestHandler<GetAccessRightsQuery, GetAccessRightsVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAccessRightsByIDQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAccessRightsVM> Handle(GetAccessRightsQuery request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.AccessRights.GetByIdAsync(request.AccessRightsId);
            var AccessRightsDto = _mapper.Map<GetAccessRightsVM>(model);

            return AccessRightsDto;
        }
    }
}
