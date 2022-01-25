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
		private IBookRepository bookRepo = new BookRepository();
		public BookHomeRepository()
		{
			this.db = new AppDbContext();
		}
		public BookHomeRepository(AppDbContext dataBase)
		{
			this.db = dataBase;
		}

		public bool IsExist(int bookId) => bookRepo.IsExist(bookId);

		public BookEntity Lord(int bookId, bool? status) => bookRepo.Lord(bookId, status);

		// 熱門書籍
		public List<BookBasicEntity> Search(BookRepositoryEntity entity)
			=> bookRepo
				.Search(entity)
				.OrderByDescending(x => x.Collections)
				.ToList();
		
		// 最近更新的書籍
		public List<BookBasicEntity> GetLatestUpdate(bool? status)
		{
			var query = db.Books.AsNoTracking();

			if(status.HasValue)query.Where(x=>x.Status == status);

			var books = query
				.Take(3)
				.OrderByDescending(x=>x.ModifiedTime)
				.ToList()
				.Select(x=>x.ToEntity());

			return books.ToList();
		}
	}
}