using System;
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
				Name = book.Name,
				Author = book.Author.Name,
				TotalWord = book.TotalWord,
				Blurb = book.Blurb
			};
		}
	}
}