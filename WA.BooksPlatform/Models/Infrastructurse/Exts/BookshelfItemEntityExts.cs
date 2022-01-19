using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class BookshelfItemEntityExts
	{
		public static BookshelfItem ToEF(this BookshelfItemEntity entity, int bookshelfId)
		{
			return new BookshelfItem
			{
				Id = entity.Id,
				BookId = entity.Book.Id,
				BookshelfId = bookshelfId
			};
		}
	}
}