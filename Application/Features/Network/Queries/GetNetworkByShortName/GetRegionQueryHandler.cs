using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.Network.Queries.GetNetworkByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Network.Queries.GetNetworkByShortName
{
    public class GetNetworkByShortNameQueryHandler : IRequestHandler<GetNetworkByShortNameQuery, GetNetworkVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetNetworkByShortNameQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetNetworkVM> Handle(GetNetworkByShortNameQuery request, CancellationToken cancellationToken)
        {
            var model = (await _unitOfWork.Network.ListAllAsync()).Where(x=>x.NormalizedName == request.ShortName).FirstOrDefault();
            var NetworkDto = _mapper.Map<GetNetworkVM>(model);

            return NetworkDto;
        }
    }
}
