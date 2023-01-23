using Application.Contracts.IUOW;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Network.Queries.GetNetworkList
{
    public class GetNetworkListQueryHandler : IRequestHandler<GetNetworkListQuery, List<GetNetworkListVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetNetworkListQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetNetworkListVM>> Handle(GetNetworkListQuery request, CancellationToken cancellationToken)
        {
            var allNetwork = (await _unitOfWork.Network.GetAll(null,null,"City"));
            return _mapper.Map<List<GetNetworkListVM>>(allNetwork);
        }
    }
}
