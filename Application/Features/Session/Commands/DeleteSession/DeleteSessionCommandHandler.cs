using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.Session.Queries.GetSessionByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Session.Commands.DeleteSession
{
    public class DeleteSessionCommandHandler : IRequestHandler<DeleteSessionCommand, GetSessionVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSessionCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetSessionVM> Handle(DeleteSessionCommand request, CancellationToken cancellationToken)
        {

            var SessionToUpdate =  await _unitOfWork.Session.GetByIdAsync(request.SessionId);
            if (SessionToUpdate.IsDeleted)
                SessionToUpdate.IsDeleted = false;
            else
                SessionToUpdate.IsDeleted = true;
            
                await _unitOfWork.Session.UpdateAsync(SessionToUpdate);
            await _unitOfWork.Commit();

            var SessionDto = _mapper.Map<GetSessionVM>(SessionToUpdate);

            return SessionDto;
        }
    }
}