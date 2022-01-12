using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Email;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.Infrastructurse.Exts;
using WA.BooksPlatform.Models.Services.Core;
using WA.BooksPlatform.Models.Services.Core.Interfaces;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Models.Services.UseCases
{
	public class RegisterCommand
	{
		public RegisterResponse Execute(RegisterVM model, string urlTemp)
		{
			MemberService member = new MemberService();

			RegisterResponse response = member.CreateNewMember(model.ToRequest());

			EmailHelper email = new EmailHelper();
			if (response.IsSuccess)
			{
				string url = string.Format(urlTemp, response.Data.Id, response.Data.ConfirmCode);
				email.SendConfirmRegisterEmail(url, model.Name, model.Email);
			}

			return response;
		}
	}
}