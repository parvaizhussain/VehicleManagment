﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Models
{
	[Table(name: "AspNetRoleMenuPermission")]
	public class RoleMenuPermission
	{
		public string RoleId { get; set; }

		public int NavigationMenuId { get; set; }

		public NavigationMenu NavigationMenu { get; set; }
	}
}
