using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class LoginVMExts
	{
		public static LoginRequest ToRequest(this LoginVM model)
		{
			return new LoginRequest
			{
				Account = model.Account,
				Password = model.Password
			};
		}
	}
}