using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial  class ForgetPasswordResetVMExts
	{
		public static ForgetPasswordRequest ToRequest(this ForgetPasswordResetVM model, int memberId, string resetConfirmCode)
		{
			return new ForgetPasswordRequest
			{
				Id = memberId,
				ConfirmCode = resetConfirmCode,
				NewPassword = model.Password
			};
		}
	}
}