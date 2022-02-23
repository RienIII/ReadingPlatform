using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Services.Core.Interfaces;
using WA.BooksPlatform.Models.Infrastructurse.Exts;

namespace WA.BooksPlatform.Models.Infrastructurse.Repositories
{
	public class BookRepository : IBookRepository
	{
		private AppDbContext db;
		public BookRepository()
		{
			this.db = new AppDbContext();
		}
		public BookRepository(AppDbContext dataBase)
		{
			this.db = dataBase;
		}
		public bool IsExist(int bookId)
		{
			return db.Books.AsNoTracking().SingleOrDefault(x => x.Id == bookId) != null;
		}
		public bool IsExist(string bookName)
		{
			return db.Books.AsNoTracking().SingleOrDefault(x=>x.Name == bookName) != null;
		}

		public BookEntity Lord(int bookId, bool? status)
		{
			var query = db.Books.AsNoTracking();

			if (status.HasValue) query.Where(x => x.Status == status.Value);

			return db.Books
				.Include(x => x.BookChapters)
				.SingleOrDefault(x => x.Id == bookId)
				.ToBookEntity();
		}

		public List<BookBasicEntity> Search(BookRepositoryEntity entity)
		{
			IQueryable<Book> query = db.Books.AsNoTracking();

			if(entity.AuthorId.HasValue) query = query.Where(x=>x.AuthorId == entity.AuthorId.Value);
			if (entity.CategoryId.HasValue) query = query.Where(x => x.CategoryId == entity.CategoryId);
			if (!string.IsNullOrEmpty(entity.BookName))query = query.Where(x => x.Name.Contains(entity.BookName));
			if (entity.Status.HasValue) query = query.Where(x => x.Status == entity.Status);

			if(entity.ForPages == null)
			{
				var books = query.Take(entity.TakeCount).ToList().Select(x => x.ToEntity());

				return books.ToList();
			}

			double count = query.Count();
			entity.ForPages = ForPagesExts.GetPages(count, entity.ForPages);

			var bookPages = query
				.OrderBy(x => x.Name)
				.Skip((entity.ForPages.NowPage - 1) * entity.ForPages.ItemNumPage)
				.Take(entity.ForPages.ItemNumPage)
				.ToList().Select(x=>x.ToEntity());

			return bookPages.ToList();
		}
	}
}