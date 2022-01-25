using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Entities;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class MemberExts
	{
		public static MemberEntity ToEntity(this Member member)
		{
			AuthorEntity author = null;
			if (member.Authors.Count > 0) author = member.Authors
													.SingleOrDefault(x=>x.MemberId == member.Id)
													.ToEntity();

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
				Author = author,
				IsConfirmed = member.IsConfirmed,
				ResetPasswordCode = member.ResetPasswordCode,
				CreateTime = member.CreateTime,
				Roles = member.Roles
			};
		}
	}
}