using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Region.Queries.GetRegionList
{
    public class GetRegionListQuery : IRequest<List<GetRegionListVM>>
    {
    }
}
