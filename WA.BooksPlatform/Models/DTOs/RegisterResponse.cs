using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Entities;

namespace WA.BooksPlatform.Models.DTOs
{
	public class RegisterResponse
	{
		public bool IsSuccess { get; set; }
		public string ErrorMessage { get; set; }
		public LoginDataEntity Data { get; set; }

		public static RegisterResponse Success(MemberEntityNoPassword entity)
		{
			return new RegisterResponse
			{
				IsSuccess = true,
				Data = new LoginDataEntity
				{
					Id = entity.Id,
					Account = entity.Account,
					Email = entity.Email,
					Name = entity.Name,
					ConfirmCode = entity.ConfirmCode,
					Role = entity.Roles
				}
			};
		}
		public static RegisterResponse Fail(string errorMsg)
		{
			return new RegisterResponse
			{
				IsSuccess = false,
				ErrorMessage = errorMsg
			};
		}
	}
}