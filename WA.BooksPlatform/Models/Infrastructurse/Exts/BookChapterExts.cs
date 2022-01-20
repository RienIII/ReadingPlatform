using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class BookChapterExts
	{
		public static BookChapterEntity ToEntity(this BookChapter chapter)
		{
			return new BookChapterEntity
			{
				Id = chapter.Id,
				Name = chapter.Name,
				Artical = chapter.Artical
			};
		}
	}
}