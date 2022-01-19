using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Entities;
using WA.BooksPlatform.Models.EFModels;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class MemberExts
	{
		public static MemberEntity ToEntity(this Member member)
		{
			return new MemberEntity(
				member.Account, 
				member.Name, 
				member.Email, 
				member.Password, 
				member.ConfirmCode
			)
			{
				Id = member.Id,
				ImageFileName = member.ImageFileName,
				IsConfirmed = member.IsConfirmed,
				ResetPasswordCode = member.ResetPasswordCode,
				CreateTime = member.CreateTime,
				Roles = member.Roles
			};
		}
	}
}