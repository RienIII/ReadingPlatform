using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HashUtilities;
using WA.BooksPlatform.Entities;

namespace WA.BooksPlatform.Models.DTOs
{
	public class ResetPasswordRequest
	{
		public string UserAccount { get; set; }
		public string OriginalPassword { get;set; }
		public string NewPassword { get; set; }
	}
}