using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Session.Queries.GetSessionList
{
    public class GetSessionListQuery : IRequest<List<GetSessionListVM>>
    {
    }
}
