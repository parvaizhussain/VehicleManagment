using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
	public class RoleViewModel
	{
		public string Id { get; set; }

		[Display(Name = "Name", Prompt = "Name")]

		public string Name { get; set; }

		public string? ShortName { get; set; }

		public bool Selected { get; set; }

		public int? GroupId { get; set; }
		public Group? Group { get; set; }
		public List<RoleUserViewModel>? roleUsers { get; set; }
	}
}
