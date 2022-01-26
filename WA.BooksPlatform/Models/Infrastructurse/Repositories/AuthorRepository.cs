using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse.Exts;
using WA.BooksPlatform.Models.Services.Core.Interfaces;

namespace WA.BooksPlatform.Models.Infrastructurse.Repositories
{
	public class AuthorRepository : IAuthorRepository
	{
		AppDbContext db;
		public AuthorRepository()
		{
			db = new AppDbContext();
		}

		public void BookChapterCreate(int bookId, BookChapterEntity entity)
		{
			BookChapter chapter = entity.ToEF(bookId);

			db.BookChapters.Add(chapter);
			db.SaveChanges();
		}

		public void BookCreate(BookEntity entity)
		{
			Book book = entity.ToEF();

			db.Books.Add(book);
			db.SaveChanges();
		}
	}
}