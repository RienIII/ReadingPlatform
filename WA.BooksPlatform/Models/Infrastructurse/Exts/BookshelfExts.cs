using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class BookshelfExts
	{
		public static BookshelfEntity ToEntity(this Bookshelf bookshelf)
		{
			var entity = bookshelf.BookshelfItems.Select(x=>x.ToEntity()).ToList();

			return new BookshelfEntity(bookshelf.MemberId)
			{
				Id = bookshelf.Id,
				Name = bookshelf.Name,
				Books = entity
			};
		}
	}
}