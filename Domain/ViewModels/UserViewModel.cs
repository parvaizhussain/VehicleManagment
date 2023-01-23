using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
	public class UserViewModel
	{
		public string Id { get; set; } 
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }

        public RoleViewModel[] Roles { get; set; }

		public int? AccessRightsId { get; set; }
		public AccessRights AccessRights { get; set; }
	
		//public int? RegionId { get; set; }
		//public Region Region { get; set; }

		public List<User_Region> User_Region { get; set; }
		public List<Cluster_Branch> Cluster_Branch { get; set; }
		public List<UserCity_Network_Branch> City_Network_Branch { get; set; }
		public string pwd { get; set; }
		public List<Tuple<int,int?>>SessionId { get; set; }
		public string Token { get; set; }
		public bool IsCluster { get; set; }
		public bool IsActive { get; set; }
    }
}
