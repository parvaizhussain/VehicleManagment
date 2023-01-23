using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.Network.Queries.GetNetworkByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Network.Commands.DeleteNetwork
{
    public class DeleteNetworkCommandHandler : IRequestHandler<DeleteNetworkCommand, GetNetworkVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteNetworkCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetNetworkVM> Handle(DeleteNetworkCommand request, CancellationToken cancellationToken)
        {

            var NetworkToUpdate =  await _unitOfWork.Network.GetByIdAsync(request.NetworkId);
            if (NetworkToUpdate.IsDeleted)
                NetworkToUpdate.IsDeleted = false;
            else
                NetworkToUpdate.IsDeleted = true;
            await _unitOfWork.Network.UpdateAsync(NetworkToUpdate);
            await _unitOfWork.Commit();

            var NetworkDto = _mapper.Map<GetNetworkVM>(NetworkToUpdate);

            return NetworkDto;
        }
    }
}