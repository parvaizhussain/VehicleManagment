using Application.Contracts.IUOW;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Network.Commands.UpdateNetwork
{
    public class UpdateNetworkCommandHandler : IRequestHandler<UpdateNetworkCommand>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateNetworkCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateNetworkCommand request, CancellationToken cancellationToken)
        {

            var NetworkToUpdate = await _unitOfWork.Network.GetByIdAsync(request.NetworkId);

            if (NetworkToUpdate == null)
            {
                throw new NotFoundException(nameof(Network), request.NetworkId);
            }

            var validator = new UpdateNetworkCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, NetworkToUpdate, typeof(UpdateNetworkCommand), typeof(Domain.Entities.Network));

            await _unitOfWork.Network.UpdateAsync(NetworkToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}