using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.ViewModels
{
	public class ManageAuthorBookCreateVM
	{
		[Display(Name = "書名")]
		[Required(ErrorMessage = "必填")]
		[StringLength(50)]
		public string Name { get; set; }

		[Display(Name = "簡介")]
		[Required(ErrorMessage = "必填")]
		[StringLength(2000)]
		public string Blurb { get; set; }

		[Display(Name = "封面圖")]
		public string ImageFilaName { get; set; }
	}
}