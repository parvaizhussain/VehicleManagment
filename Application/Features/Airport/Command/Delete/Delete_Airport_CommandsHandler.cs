using Application.Contracts.IUOW;
using Application.Features.Airport.Querys.GetByID;

using Application.Features.City.Queries.GetCityByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Airport.Command.Delete
{
    public class Delete_Airport_CommandsHandler : IRequestHandler<Delete_Airport_Commands, Get_Airport_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Delete_Airport_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_Airport_VM> Handle(Delete_Airport_Commands request, CancellationToken cancellationToken)
        {

            var DeletetoUpdate = await _unitOfWork.Airport.GetByIdAsync(request.AirportID);
            if (DeletetoUpdate.IsDeleted)
                DeletetoUpdate.IsDeleted = false;
            else
                DeletetoUpdate.IsDeleted = true;
            await _unitOfWork.Airport.UpdateAsync(DeletetoUpdate);
            await _unitOfWork.Commit();

            var AirportDto = _mapper.Map<Get_Airport_VM>(DeletetoUpdate);

            return AirportDto;
        }


    }
}
