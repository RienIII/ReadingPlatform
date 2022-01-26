using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class BookChapterCreateRequestExts
	{
		public static BookChapterEntity ToEntity(this BookChapterCreateRequest request)
		{
			return new BookChapterEntity
			{
				Name = request.Name,
				Artical = request.Artical,
				CreateTime = request.CreateTime
			};
		}
	}
}