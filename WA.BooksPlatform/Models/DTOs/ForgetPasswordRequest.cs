using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.DTOs
{
	public class ForgetPasswordRequest
	{
		public int Id { get; set; }
		public string Account { get; set; }
		public string ResetPasswordCode { get; set; }
		public string NewPassword { get; set; }
	}
}