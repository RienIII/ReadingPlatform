using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.DTOs
{
	public class BecomeAuthorResponse
	{
		public bool IsSuccess { get; set; }
		public string ErrorMessage { get; set; }
		public static BecomeAuthorResponse Fail(string errorMsg)
			=>new BecomeAuthorResponse
			{
				IsSuccess = false,
				ErrorMessage = errorMsg
			};
		public static BecomeAuthorResponse Success() => new BecomeAuthorResponse { IsSuccess = true };		
	}
}