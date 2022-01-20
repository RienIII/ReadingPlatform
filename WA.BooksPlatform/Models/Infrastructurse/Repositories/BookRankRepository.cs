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
	public class BookRankRepository : IBookRankRepository
	{
		private AppDbContext db;
		public BookRankRepository()
		{
			this.db = new AppDbContext();
		}
		public BookRankRepository(AppDbContext dataBase)
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
		public List<BookBasicEntity> Search(int? categoryId, string bookName, bool? status)
		{
			var query = db.Books.AsNoTracking();

			if (categoryId.HasValue) query.Where(x => x.CategoryId == categoryId);
			if(!string.IsNullOrEmpty(bookName))query.Where(x=>x.Name.Contains(bookName));
			if (status.HasValue) query.Where(x => x.Status == status);

			var books = query.ToList().Select(x => x.ToEntity());

			return books.OrderByDescending(x=>x.Collections).Take(10).ToList();
		}
	}
}