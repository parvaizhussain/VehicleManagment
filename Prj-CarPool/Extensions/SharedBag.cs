using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prj_CarPool.Extensions
{
    public class SharedBag
    {
        public const string JWToken = "JWToken";
        public const string UserId = "UserId";
        public const string UName = "UserName";
        public const string UserAccountDetail = "UserAccountDetail";



        public const string APIBaseUrl = "https://localhost:7112/";
        public const string AuthenticateAPIPath = APIBaseUrl + "api/Account/authenticate/";

        public const string BranchUpsert = APIBaseUrl + "api/Branch/";
        public const string BranchDelete = APIBaseUrl + "api/Branch/DeleteBranch";
        public const string Branchlist = APIBaseUrl + "api/Branch/all";

        public const string VehicleCompanyUpsert = APIBaseUrl + "api/VehicleCompany/";
        public const string VehicleCompanyDelete = APIBaseUrl + "api/VehicleCompany/DeleteVC";
        public const string VehicleCompanylist = APIBaseUrl + "api/VehicleCompany/all";
    }
}
