using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class AuthorEntityExts
	{
		public static Author ToEF(this AuthorEntity entity)
		{
			return new Author
			{
				Id = entity.Id,
				Name = entity.Name,
				MemberId = entity.MemberId
			};
		}
	}
}