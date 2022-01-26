using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.DTOs
{
	public class CreateBookResponse
	{
		public bool IsSuccess { get; set; }
		public string ErrorMessage { get; set; }
		public static CreateBookResponse Success()=> new CreateBookResponse { IsSuccess = true };
		public static CreateBookResponse Fail(string message) 
			=> new CreateBookResponse 
			{
				IsSuccess = false,
				ErrorMessage = message				
			};
	}
}