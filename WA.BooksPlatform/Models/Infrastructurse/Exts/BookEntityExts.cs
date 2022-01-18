using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.Entities;

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
	}
}