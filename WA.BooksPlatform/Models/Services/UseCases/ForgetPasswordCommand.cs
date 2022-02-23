using Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;

namespace WA.BooksPlatform.Models.Services.UseCases
{
	public class ForgetPasswordCommand
	{
		public void Execute(RegisterResponse response, string urlTemplate)
		{
			if (!response.IsSuccess) return;
			
			string result = string.Format(urlTemplate, response.Data.Id, response.Data.ResetPasswordCode);
			new EmailHelper().SendForgetPasswordEmail(result, response.Data.Name, response.Data.Email);
			
		}
	}
}