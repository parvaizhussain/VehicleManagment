using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.Region.Queries.GetRegionByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Region.Commands.DeleteRegion
{
    public class DeleteRegionCommandHandler : IRequestHandler<DeleteRegionCommand, GetRegionVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteRegionCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetRegionVM> Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
        {

            var RegionToUpdate =  await _unitOfWork.Region.GetByIdAsync(request.RegionId);
            if (RegionToUpdate.IsDeleted)
                RegionToUpdate.IsDeleted = false;
            else
                RegionToUpdate.IsDeleted = true;
            
            await _unitOfWork.Region.UpdateAsync(RegionToUpdate);
            await _unitOfWork.Commit();

            var RegionDto = _mapper.Map<GetRegionVM>(RegionToUpdate);

            return RegionDto;
        }
    }
}