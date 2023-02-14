﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Models
{
	[Table(name: "AspNetNavigationMenu")]
	public class NavigationMenu
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public string? Name { get; set; }

		[ForeignKey("ParentNavigationMenu")]
		public int? ParentMenuId { get; set; }

		public virtual NavigationMenu ParentNavigationMenu { get; set; }

		public string? Area { get; set; }

		public string? ControllerName { get; set; }

		public string? ActionName { get; set; }

		public bool IsExternal { get; set; }
		public bool IsButton { get; set; }

		public string? ButtonClass { get; set; }

		[StringLength(5)]
		public string? StatusCode { get; set; }

		public string? ExternalUrl { get; set; }

		public int DisplayOrder { get; set; }

		[NotMapped]
		public bool? Permitted { get; set; }

		public bool Visible { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
		public string? CssClass { get; set; }
		public string? IdClass { get; set; }
	}
}
