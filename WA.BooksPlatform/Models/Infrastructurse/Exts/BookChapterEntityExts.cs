using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class BookChapterEntityExts
	{
		public static BookChapter ToVM(this BookChapterEntity entity)
		{
			return new BookChapter
			{
				Id = entity.Id,
				Name = entity.Name,
				Artical = entity.Artical
			};
		}
	}
}