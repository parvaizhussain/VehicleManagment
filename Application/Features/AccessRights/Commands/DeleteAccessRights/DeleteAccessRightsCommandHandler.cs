using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.AccessRights.Queries.GetAccessRightsByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.AccessRights.Commands.DeleteAccessRights
{
    public class DeleteAccessRightsCommandHandler : IRequestHandler<DeleteAccessRightsCommand, GetAccessRightsVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAccessRightsCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAccessRightsVM> Handle(DeleteAccessRightsCommand request, CancellationToken cancellationToken)
        {

            var AccessRightsToUpdate =  await _unitOfWork.AccessRights.GetByIdAsync(request.AccessId);
            if (AccessRightsToUpdate.IsDeleted)
                AccessRightsToUpdate.IsDeleted = false;
            else 
                AccessRightsToUpdate.IsDeleted = true;
            await _unitOfWork.AccessRights.UpdateAsync(AccessRightsToUpdate);
            await _unitOfWork.Commit();

            var AccessRightsDto = _mapper.Map<GetAccessRightsVM>(AccessRightsToUpdate);

            return AccessRightsDto;
        }
    }
}