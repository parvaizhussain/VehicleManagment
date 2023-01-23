using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.City.Queries.GetCityByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.City.Commands.DeleteCity
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, GetCityVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCityCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetCityVM> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {

            var CityToUpdate =  await _unitOfWork.City.GetByIdAsync(request.CityId);
            if (CityToUpdate.IsDeleted)
                CityToUpdate.IsDeleted = false;
            else
                CityToUpdate.IsDeleted = true;
            await _unitOfWork.City.UpdateAsync(CityToUpdate);
            await _unitOfWork.Commit();

            var CityDto = _mapper.Map<GetCityVM>(CityToUpdate);

            return CityDto;
        }
    }
}