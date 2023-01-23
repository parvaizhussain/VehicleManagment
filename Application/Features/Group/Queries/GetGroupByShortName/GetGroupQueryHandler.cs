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

namespace Application.Features.Group.Queries.GetGroupByShortName
{
    public class GetGroupByShortNameQueryHandler : IRequestHandler<GetGroupByShortNameQuery, GetGroupVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGroupByShortNameQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetGroupVM> Handle(GetGroupByShortNameQuery request, CancellationToken cancellationToken)
        {
            var model = (await _unitOfWork.Group.ListAllAsync()).Where(x=>x.NormalizedName == request.ShortName).FirstOrDefault();
            var GroupDto = _mapper.Map<GetGroupVM>(model);

            return GroupDto;
        }
    }
}
