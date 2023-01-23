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

namespace Application.Features.Network.Queries.GetNetworkByCityID
{
    public class GetNetworkByCityIDQueryHandler : IRequestHandler<GetCityNetworkQuery, List<GetNetworkVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetNetworkByCityIDQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetNetworkVM>> Handle(GetCityNetworkQuery request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.Network.GetAll(x=>x.CityId == request.CityId, null,"City");
            var NetworkDto = _mapper.Map<List<GetNetworkVM>>(model);

            return NetworkDto;
        }
    }
}
