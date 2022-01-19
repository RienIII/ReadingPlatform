using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class BookshelfEntityExts
	{
		public static Bookshelf ToEF(this BookshelfEntity entity)
		{
			var bookshelf = entity.Books.Select(x=>x.ToEF(entity.Id)).ToList();

			return new Bookshelf
			{
				Id = entity.Id,
				Name = entity.Name,
				BookshelfItems = bookshelf,
				MemberId = entity.MemberId
			};
		}
	}
}