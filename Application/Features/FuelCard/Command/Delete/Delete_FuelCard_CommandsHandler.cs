using Application.Contracts.IUOW;
using Application.Features.Airport.Command.Delete;
using Application.Features.Airport.Querys.GetByID;
using Application.Features.City.Commands.DeleteCity;
using Application.Features.City.Queries.GetCityByID;
using Application.Features.FuelCard.Querys.GetByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FuelCard.Command.Delete
{
    public class Delete_FuelCard_CommandsHandler : IRequestHandler<Delete_FuelCard_Commands, Get_FuelCard_VM>
    {

        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Delete_FuelCard_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_FuelCard_VM> Handle(Delete_FuelCard_Commands request, CancellationToken cancellationToken)
        {

            var DeletetoUpdate = await _unitOfWork.FuelCard.GetByIdAsync(request.CardID);
            if (DeletetoUpdate.IsDeleted)
                DeletetoUpdate.IsDeleted = false;
            else
                DeletetoUpdate.IsDeleted = true;
            await _unitOfWork.FuelCard.UpdateAsync(DeletetoUpdate);
            await _unitOfWork.Commit();

            var FuelCardDto = _mapper.Map<Get_FuelCard_VM>(DeletetoUpdate);

            return FuelCardDto;
        }

    }
}
