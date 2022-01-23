using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.DTOs
{
	public class LoginResponse
	{
		public bool IsSuccess { get; set; }
		public string ErrorMessage { get; set; }
		public string Roles { get; set; }
		public static LoginResponse Success(string roles)
			=>new LoginResponse
			{
				IsSuccess = true,
				Roles = roles
			};
		
		public static LoginResponse Fail(string errorMsg)
			=>new LoginResponse
			{
				IsSuccess = false,
				ErrorMessage = errorMsg
			};
	}
}