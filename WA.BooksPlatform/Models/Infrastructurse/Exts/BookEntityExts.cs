using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.EFModels;
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
				ImageFileName = entity.ImageFileName,
				Name = entity.Name,
				Blurb = entity.Blurb,
				Author = entity.AuthorName,
				TotalWord = entity.TotalWord,
				Category = entity.Category.Name,
				Likes = entity.Likes,
				Clicks = entity.Clicks,
				Collections = entity.Collection,
				ModifiedTime = entity.ModifiedTime
			};
		}
		public static BookshelfItemEntity ToBookshelfItem(this BookEntity entity)
		{
			return new BookshelfItemEntity
			{
				Id = entity.Id,
				Book = entity.ToBookBasic(),
				WatchTime = DateTime.Now,
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
				Author=entity.AuthorName,
				ImageFileName = entity.ImageFileName,
				Category = entity.Category,
				Status = entity.Status,
				ModifiedTime = entity.ModifiedTime,
				Likes = entity.Likes,
				Clicks = entity.Clicks,
				Collection = entity.Collection
			};
		}
		public static Book ToEF(this BookEntity entity)
		{
			return new Book
			{
				Name = entity.Name,
				Blurb = entity.Blurb,
				AuthorId = entity.Author.Id,
				Clicks = entity.Clicks,
				Likes = entity.Likes,
				Collections = entity.Collection,
				ImageFileName = entity.ImageFileName,
				Status = entity.Status,
				TotalWord = entity.TotalWord,
				CategoryId = entity.CategoryId
			};
		}
	}
}