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
	public class BookHomeRepository : IBookHomeRepository
	{
		private AppDbContext db;
		public BookHomeRepository()
		{
			this.db = new AppDbContext();
		}
		public BookHomeRepository(AppDbContext dataBase)
		{
			this.db = dataBase;
		}

		public bool IsExist(int bookId)
		{
			return db.Books.AsNoTracking().SingleOrDefault(x=>x.Id == bookId) != null;
		}

		public BookEntity Lord(int bookId, bool? status)
		{
			var query = db.Books.AsNoTracking();

			if(status.HasValue)query.Where(x=>x.Status == status.Value);

			return db.Books
				.AsNoTracking()
				.Include(x => x.BookChapters)
				.SingleOrDefault(x => x.Id == bookId)
				.ToBookEntity();
		}

		// 熱門書籍
		public List<BookBasicEntity> Search(int? categoryId, string bookName, bool? status)
		{
			var query = db.Books.AsNoTracking();

			if (categoryId.HasValue) query.Where(x => x.CategoryId == categoryId);
			if (!string.IsNullOrEmpty(bookName)) query.Where(x => x.Name.Contains(bookName));
			if (status.HasValue) query.Where(x => x.Status == status);

			var books = query.OrderByDescending(x=>x.Collections).ToList().Select(x => x.ToEntity());

			return books.Take(4).ToList();
		}
		// 最近更新的書籍
		public List<BookBasicEntity> GetAllBooks(bool? status)
		{
			var query = db.Books.AsNoTracking();

			if(status.HasValue)query.Where(x=>x.Status == status);

			var books = query
				.OrderByDescending(x=>x.ModifiedTime)
				.ToList()
				.Select(x=>x.ToEntity());

			return books.Take(4).ToList();
		}
	}
}