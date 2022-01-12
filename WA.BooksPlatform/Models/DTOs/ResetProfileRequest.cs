using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.DTOs
{
	public class ResetProfileRequest
	{
		public string UserAccount { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string ImageFileName { get; set; }
	}
}