using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.DTOs
{
	public class CommonResponse
	{
		public bool IsSuccess { get; set; }
		public string ErrorMessage { get; set; }

		public static CommonResponse Success() 
			=> new CommonResponse { IsSuccess = true };

		public static CommonResponse Fail(string errorMsg)
			=> new CommonResponse { ErrorMessage = errorMsg, IsSuccess = false };
	}
}