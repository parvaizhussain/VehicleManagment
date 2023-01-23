using Application.Contracts.IUOW;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Application.Features.Session.Queries.GetSessionByID
{
    public class GetSessionQueryHandler : IRequestHandler<GetSessionQuery, GetSessionVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSessionQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetSessionVM> Handle(GetSessionQuery request, CancellationToken cancellationToken)
        {
            var model = (await _unitOfWork.Session.GetAll(x=>x.SessionID == request.SessionID, null, "Region")).OrderBy(x => x.Name);
            var EmployeeDto = _mapper.Map<GetSessionVM>(model);

            return EmployeeDto;
        }
    }
}