using System;
using System.Collections.Generic;
using System.Configuration;
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
		private readonly string connStr = ConfigurationManager
											.ConnectionStrings["AppDbContext"]
											.ToString();
		AppDbContext db;
		public AuthorRepository()
		{
			db = new AppDbContext();
		}
		public BookChapterEntity LordChapter(int chapterId)=>db.BookChapters.Find(chapterId).ToEntity();

		public void BookChapterCreate(int bookId, BookChapterEntity entity)
		{
			db.BookChapters.Add(entity.ToEF(bookId));
			db.SaveChanges();

			Update(null, bookId);
		}

		public void BookCreate(BookEntity entity)
		{
			db.Books.Add(entity.ToEF());
			db.SaveChanges();
		}

		public void BookChapterUpdate(BookChapterEntity entity)
		{
			var chapter = db.BookChapters.SingleOrDefault(x=>x.Id == entity.Id);

			chapter.Name = entity.Name;
			chapter.Artical = entity.Artical;
			chapter.WordCount = entity.WordCount;

			db.SaveChanges();

			Update(entity.Id, null);
		}
		public void Update(int? chapterId, int? bookId = 0)
		{
			int totalWord;
			if (bookId.HasValue)
			{
				totalWord = db.Books.Find(bookId).ToBookEntity().TotalWord;
			}
			if (chapterId.HasValue)
			{
				bookId = db.BookChapters.Find(chapterId).BookId;
				totalWord = db.Books.Find(bookId).ToBookEntity().TotalWord;
			}
			else return;

			var book = db.Books.Find(bookId);
			book.TotalWord = totalWord;
			book.ModifiedTime = DateTime.Now;

			db.SaveChanges();
		}
	}
}