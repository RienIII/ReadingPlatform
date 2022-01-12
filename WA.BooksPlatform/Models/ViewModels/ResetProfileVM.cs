using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.ViewModels
{
	public class ResetProfileVM
	{
		public string UserAccount { get; set; }

		[Display(Name = "暱稱")]
		[StringLength(50)]
		public string Name { get; set; }

		[Display(Name = "暱稱")]
		[StringLength(256)]
		[EmailAddress]
		public string Email { get; set; }
		public string ImageFileName { get; set; }
		public HttpPostedFileBase File { get; set; }
	}
}