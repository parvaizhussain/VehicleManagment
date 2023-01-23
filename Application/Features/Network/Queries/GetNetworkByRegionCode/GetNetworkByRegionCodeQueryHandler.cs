using Application.Contracts.IUOW;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Network.Queries.GetNetworkByRegionCode
{
    public class GetNetworkByRegionCodeQueryHandler : IRequestHandler<GetNetworkByRegionCodeQuery, List<GetNetworkByRegionCodeVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetNetworkByRegionCodeQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetNetworkByRegionCodeVM>> Handle(GetNetworkByRegionCodeQuery request, CancellationToken cancellationToken)
        {
            var allNetwork = (await _unitOfWork.Network.GetAll(null, null, "City")).Where(x => x.RegionCode == request.RegionCode).ToList();
            return _mapper.Map<List<GetNetworkByRegionCodeVM>>(allNetwork);
        }
    }
}
