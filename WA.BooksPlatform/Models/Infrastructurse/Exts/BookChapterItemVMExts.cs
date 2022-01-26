using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class BookChapterItemVMExts
	{
		public static BookChapterCreateRequest ToRequest(this BookChapterItemVM model)
		{
			return new BookChapterCreateRequest
			{
				Id = model.Id,
				Name = model.Name,
				Artical = model.Artical,
				WordCount = model.WordCount,
				CreateTime = model.CreateTime
			};
		}
	}
}