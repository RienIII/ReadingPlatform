using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class AuthorExts
	{
		public static AuthorEntity ToEntity(this Author author)
		{
			return new AuthorEntity
			{
				Id = author.Id,
				Name = author.Name,
				MemberId = author.MemberId
			};
		}
	}
}