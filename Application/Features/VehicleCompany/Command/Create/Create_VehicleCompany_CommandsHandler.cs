using Application.Contracts.IUOW;
using Application.Features.Vehicle.Command.CreateVehicle;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleCompany.Command.Create
{
    public class Create_VehicleCompany_CommandsHandler : IRequestHandler<Create_VehicleCompany_Commands, Create_VehicleCompany_CommandsResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Create_VehicleCompany_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Create_VehicleCompany_CommandsResponse> Handle(Create_VehicleCompany_Commands request, CancellationToken cancellationToken)
        {
            var createVehicleCompanyCommandResponse = new Create_VehicleCompany_CommandsResponse();

            var validator = new Create_VehicleCompany_CommandsValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createVehicleCompanyCommandResponse.Success = false;
                createVehicleCompanyCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createVehicleCompanyCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createVehicleCompanyCommandResponse.Success)
            {
                var VehicleCompany = _mapper.Map<Domain.Entities.VehicleCompany>(request);
                VehicleCompany = await _unitOfWork.VehicleCompany.AddAsync(VehicleCompany);
                VehicleCompany = (Domain.Entities.VehicleCompany)await _unitOfWork.Commit(VehicleCompany, "Insert", "VehicleCompany");
                createVehicleCompanyCommandResponse._VehicleCompany_Dto = _mapper.Map<Create_VehicleCompany_Dto>(VehicleCompany);
            }

            return createVehicleCompanyCommandResponse;
        }

    }
}
