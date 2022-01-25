using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class BookEntityExts
	{
		public static BookBasicEntity ToBookBasic(this BookEntity entity)
		{
			return new BookBasicEntity
			{
				Id = entity.Id,
				Name = entity.Name,
				Blurb = entity.Blurb,
				Author = entity.Author,
				TotalWord = entity.TotalWord
			};
		}
		public static BookVM ToVM(this BookEntity entity)
		{
			var chapter = entity.GetItems().Select(x=>x.ToVM());
			var chapterVM = new BookChapterVM { Chapter = chapter.ToList(), ForPages = null };

			return new BookVM()
			{
				Chapter = chapterVM,
				Id = entity.Id,
				Name=entity.Name,
				Blurb = entity.Blurb,
				Author=entity.Author,
				ImageFileName = entity.ImageFileName,
				Category = entity.Category,
				Status = entity.Status,
				ModifiedTime = entity.ModifiedTime,
				Likes = entity.Likes,
				Clicks = entity.Clicks,
				Collection = entity.Collection
			};
		}
	}
}