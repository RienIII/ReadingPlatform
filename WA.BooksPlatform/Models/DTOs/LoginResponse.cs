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
		public static LoginResponse Success()
			=>new LoginResponse
			{
				IsSuccess = true
			};
		
		public static LoginResponse Fail(string errorMsg)
			=>new LoginResponse
			{
				IsSuccess = false,
				ErrorMessage = errorMsg
			};
	}
}