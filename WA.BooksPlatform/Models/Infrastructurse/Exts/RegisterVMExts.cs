using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class RegisterVMExts
	{
		public static RegisterRequest ToRequest(this RegisterVM model)
		{
			return new RegisterRequest
			{
				Account = model.Account,
				Password = model.Password,
				Name = model.Name,
				Email = model.Email
			};
		}
	}
}