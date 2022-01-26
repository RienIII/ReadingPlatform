using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class CreateBookRequestExts
	{
		public static BookEntity ToEntity(this CreateBookRequest request, AuthorEntity author)
		{
			return new BookEntity(request.Name, author.Name, request.Blurb)
			{
				Status = true,
				Clicks = 0,
				Likes = 0,
				Collection = 0,
				Author = author,
				CategoryId = request.CategoryId
			};
		}
	}
}