using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.Group.Queries.GetGroupByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Group.Commands.DeleteGroup
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, GetGroupVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteGroupCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetGroupVM> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {

            var GroupToUpdate =  await _unitOfWork.Group.GetByIdAsync(request.GroupId);
            if (GroupToUpdate.IsDeleted)
                GroupToUpdate.IsDeleted = false;
            else
                GroupToUpdate.IsDeleted = true;
            await _unitOfWork.Group.UpdateAsync(GroupToUpdate);
            await _unitOfWork.Commit();

            var GroupDto = _mapper.Map<GetGroupVM>(GroupToUpdate);

            return GroupDto;
        }
    }
}