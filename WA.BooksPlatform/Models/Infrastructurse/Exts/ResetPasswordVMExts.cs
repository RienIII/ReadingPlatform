using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class ResetPasswordVMExts
	{
		public static ResetPasswordRequest ToRequest(this ResetPasswordVM model, string userAccount)
		{
			return new ResetPasswordRequest
			{
				UserAccount = userAccount,
				OriginalPassword = model.OriginalPassword,
				NewPassword = model.Password
			};
		}
	}
}