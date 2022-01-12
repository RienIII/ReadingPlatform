using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Entities;
using WA.BooksPlatform.Models.DTOs;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class ResetProfileRequestExts
	{
		public static MemberEntityNoPassword ToEntity(this ResetProfileRequest request)
			=> new MemberEntityNoPassword(request.UserAccount, request.Name, request.Email) { ImageFileName = request.ImageFileName };
	}
}