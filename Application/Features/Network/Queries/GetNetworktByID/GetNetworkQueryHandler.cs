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

namespace Application.Features.Network.Queries.GetNetworkByID
{
    public class GetNetworkByIDQueryHandler : IRequestHandler<GetNetworkQuery, GetNetworkVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetNetworkByIDQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetNetworkVM> Handle(GetNetworkQuery request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.Network.GetAll(x=>x.NetworkId == request.NetworkId,null,"City");
            var NetworkDto = _mapper.Map<GetNetworkVM>(model.FirstOrDefault());

            return NetworkDto;
        }
    }
}
