using Application.Features.City.Queries.GetCityByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleCompany.Querys.GetByID
{
    public class Get_VehicleCompany_Query : IRequest<Get_VehicleCompany_VM>
    {
        public int VehicleCompanyId { get; set; }
        public string VehicleCompanyName { get; set; }
    }
}
