﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class BookExts
	{
		public static BookBasicEntity ToEntity(this Book book)
		{
			return new BookBasicEntity
			{
				Id = book.Id,
				ImageFileName = book.ImageFileName,
				Name = book.Name,
				Author = book.Author.Name,
				TotalWord = book.TotalWord,
				Blurb = book.Blurb,
				Collections = book.Collections,
				Likes = book.Likes,
				Clicks = book.Clicks,
				ModifiedTime = book.ModifiedTime
			};
		}
		public static BookEntity ToBookEntity(this Book book)
		{
			var items = book.BookChapters.Select(x=>x.ToEntity()).ToList();

			return new BookEntity
			(
				book.Id, 
				book.ImageFileName, 
				book.Name, 
				book.Author.Name, 
				book.Blurb, 
				items, 
				book.Status
			);
		}
	}
}