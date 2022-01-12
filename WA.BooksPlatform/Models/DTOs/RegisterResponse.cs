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
		public RegisterEntity Data { get; set; }

		public static RegisterResponse Success(MemberEntityNoPassword entity)
		{
			return new RegisterResponse
			{
				IsSuccess = true,
				Data = new RegisterEntity
				{
					Id = entity.Id,
					Account = entity.Account,
					Email = entity.Email,
					Name = entity.Name,
					ConfirmCode = entity.ConfirmCode
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