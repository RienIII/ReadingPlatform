using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class BookshelfItemExts
	{
		public static BookshelfItemEntity ToEntity(this BookshelfItem bookshelfItem)
		{
			var item = bookshelfItem.Book.ToEntity();

			return new BookshelfItemEntity
			{
				Id = bookshelfItem.Id,
				Book = item
			};
		}
	}
}