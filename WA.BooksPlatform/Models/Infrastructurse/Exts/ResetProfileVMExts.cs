using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class ResetProfileVMExts
	{
		public static ResetProfileRequest ToRequest(this ResetProfileVM model)
		{
			return new ResetProfileRequest
			{
				UserAccount = model.UserAccount,
				Name = model.Name,
				Email = model.Email,
				ImageFileName = model.ImageFileName
			};
		}
	}
}