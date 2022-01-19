using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Entities;
using WA.BooksPlatform.Models.EFModels;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class MemberEntityExts
	{
		public static Member ToEF(this MemberEntity entity)
		{
			return new Member
			{
				Id = entity.Id,
				Name = entity.Name,
				Account = entity.Account,
				Password = entity.EnctryptedPassword,
				Email = entity.Email,
				IsConfirmed = entity.IsConfirmed,
				ConfirmCode = entity.ConfirmCode,
				ResetPasswordCode = entity.ResetPasswordCode,
				ImageFileName = entity.ImageFileName,
				CreateTime = DateTime.Now,
				Roles = entity.Roles
			};
		}
	}
}