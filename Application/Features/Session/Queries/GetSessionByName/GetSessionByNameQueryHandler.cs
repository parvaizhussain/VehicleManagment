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

namespace Application.Features.Session.Queries.GetSessionByName
{
    public class GetSessionByNameQueryHandler : IRequestHandler<GetSessionByNameQuery, GetSessionByNameVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSessionByNameQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetSessionByNameVM> Handle(GetSessionByNameQuery request, CancellationToken cancellationToken)
        {
            var StudentRegistration = (await _unitOfWork.Session.GetAll(null, null, "Region")).FirstOrDefault();
            return _mapper.Map<GetSessionByNameVM>(StudentRegistration);
        }
    }
}