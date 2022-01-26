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
	public class BookSearchRepository : IBookSearchRepository
	{
		private AppDbContext db;
		private IBookRepository bookRepo = new BookRepository();
		public BookSearchRepository()
		{
			this.db = new AppDbContext();
		}
		public BookSearchRepository(AppDbContext dataBase)
		{
			this.db = dataBase;
		}
		public bool IsExist(int bookId) => bookRepo.IsExist(bookId);
		public bool IsExist(string bookName) => bookRepo.IsExist(bookName);
		public BookEntity Lord(int bookId, bool? status) => bookRepo.Lord(bookId, status);
		public List<BookBasicEntity> Search(BookRepositoryEntity entity)
			=> bookRepo
				.Search(entity)
				.OrderBy(x=>x.Name)
				.ToList();
	}
}