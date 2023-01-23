using Application.Contracts.IUOW;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleCompany.Command.Update
{
    public class Update_VehicleCompany_CommadsHandler : IRequestHandler<Update_VehicleCompany_Commads>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Update_VehicleCompany_CommadsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Update_VehicleCompany_Commads request, CancellationToken cancellationToken)
        {

            var VehicleCompanyToUpdate = await _unitOfWork.VehicleCompany.GetByIdAsync(request.VehicleCompanyId);

            if (VehicleCompanyToUpdate == null)
            {
                throw new NotFoundException(nameof(VehicleCompany), request.VehicleCompanyId);
            }

            var validator = new Update_VehicleCompany_CommadsValidators();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, VehicleCompanyToUpdate, typeof(Update_VehicleCompany_Commads), typeof(Domain.Entities.VehicleCompany));

            await _unitOfWork.VehicleCompany.UpdateAsync(VehicleCompanyToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}