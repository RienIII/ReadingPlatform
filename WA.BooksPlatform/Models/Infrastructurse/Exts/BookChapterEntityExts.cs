using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class BookChapterEntityExts
	{
		public static BookChapterItemVM ToVM(this BookChapterEntity entity)
		{
			return new BookChapterItemVM
			{
				Id = entity.Id,
				Name = entity.Name,
				Artical = entity.Artical,
				CreateTime = entity.CreateTime
			};
		}
		public static BookChapter ToEF(this BookChapterEntity entity, int bookId)
		{
			return new BookChapter
			{
				Name = entity.Name,
				Artical = entity.Artical,
				Status = 1,
				CreateTime = DateTime.Now,
				BookId = bookId,
				WordCount = entity.WordCount
			};
		}
	}
}