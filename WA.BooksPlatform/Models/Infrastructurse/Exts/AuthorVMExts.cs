using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class AuthorVMExts
	{
		public static BecomeAuthorRequest ToRequest(this AuthorVM model, string userName)
			=>new BecomeAuthorRequest
			{
				Id = model.Id,
				Author = model.Name,
				MemberId = model.MemberId,
				UserName = userName
			};
	}
}