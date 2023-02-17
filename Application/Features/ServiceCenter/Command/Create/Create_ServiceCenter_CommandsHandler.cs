using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceCenter.Command.Create
{
    public class Create_ServiceCenter_CommandsHandler : IRequestHandler<Create_ServiceCenter_Commands, Create_ServiceCenter_CommandsResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Create_ServiceCenter_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Create_ServiceCenter_CommandsResponse> Handle(Create_ServiceCenter_Commands request, CancellationToken cancellationToken)
        {
            var createServiceCenterCommandResponse = new Create_ServiceCenter_CommandsResponse();

            var validator = new Create_ServiceCenter_CommandsValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createServiceCenterCommandResponse.Success = false;
                createServiceCenterCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createServiceCenterCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createServiceCenterCommandResponse.Success)
            {
                var ServiceCenter = _mapper.Map<Domain.Entities.ServiceCenter>(request);
                ServiceCenter.VehicleCompanyID = request.DealerID;
                ServiceCenter.IsActive = true;
                ServiceCenter = await _unitOfWork.ServiceCenter.AddAsync(ServiceCenter);
                ServiceCenter = (Domain.Entities.ServiceCenter)await _unitOfWork.Commit(ServiceCenter, "Insert", "ServiceCenter");
                createServiceCenterCommandResponse._ServiceCenter_Dto = _mapper.Map<Create_ServiceCenter_Dto>(ServiceCenter);
            }

            return createServiceCenterCommandResponse;
        }

    }
}
