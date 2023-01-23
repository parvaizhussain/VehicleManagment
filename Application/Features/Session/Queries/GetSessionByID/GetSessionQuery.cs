using System;
using MediatR;
using System.Collections.Generic;
using System.Text;


namespace Application.Features.Session.Queries.GetSessionByID
{
    public class GetSessionQuery : IRequest<GetSessionVM>
    {
        public int SessionID { get; set; }
    }
}
