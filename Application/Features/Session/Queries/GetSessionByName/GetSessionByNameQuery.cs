using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Session.Queries.GetSessionByName
{
    public class GetSessionByNameQuery : IRequest<GetSessionByNameVM>
    {
        public string Name { get; set; }
    }
}
