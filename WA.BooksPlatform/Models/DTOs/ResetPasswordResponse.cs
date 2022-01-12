using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.DTOs
{
	public class ResetPasswordResponse
	{
		public bool IsSuccess { get; set; }
		public string ErrorMessage { get; set; }
		public static ResetPasswordResponse Success()
			=>new ResetPasswordResponse
			{
				IsSuccess = true
			};
		public static ResetPasswordResponse Fail(string errorMsg)
			=> new ResetPasswordResponse
			{
				IsSuccess = false,
				ErrorMessage = errorMsg
			};
	}
}