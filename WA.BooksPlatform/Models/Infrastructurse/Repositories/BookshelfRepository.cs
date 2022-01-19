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
	public class BookshelfRepository : IBookshelfRepository
	{
		private AppDbContext db;
		public BookshelfRepository()
		{
			db = new AppDbContext();
		}
		public BookshelfRepository(AppDbContext dataBase)
		{
			this.db = dataBase;
		}
		public BookshelfEntity CreateNewBookshelf(int memberId)
		{
			Bookshelf bookshelf = new Bookshelf { MemberId = memberId};

			db.Bookshelfs.Add(bookshelf);
			db.SaveChanges();

			return Lord(memberId);
		}
		public bool IsExist(int memberId)
		{
			return db.Bookshelfs.AsNoTracking().SingleOrDefault(x=>x.MemberId == memberId) != null;
		}
		public BookshelfEntity Lord(int memberId)
		{
			return db.Bookshelfs
				.AsNoTracking()
				.Include(x => x.BookshelfItems.Select(x2=>x2.Book))
				.SingleOrDefault(x=>x.MemberId==memberId)
				.ToEntity();
		}
		public void Save(BookshelfEntity entity)
		{
			Bookshelf bookshelf = entity.ToEF();

			Bookshelf efInDb = db.Bookshelfs
				.Include(x=>x.BookshelfItems)
				.SingleOrDefault(x=>x.Id == entity.Id);

			List<BookshelfItem> efItemInDb = efInDb.BookshelfItems.ToList();

			var delectBook = efItemInDb
				.Select(x => x.BookId)
				.Except(bookshelf.BookshelfItems.Select(x => x.BookId))
				.ToList();

			foreach (var item in delectBook)
			{
				var delectItem = efInDb.BookshelfItems.SingleOrDefault(x => x.BookId == item);

				db.Entry(item).State = EntityState.Modified;
			}

			foreach (var item in bookshelf.BookshelfItems)
			{
				if(item.Id == 0)
				{
					efInDb.BookshelfItems.Add(item);
				}
			}

			db.SaveChanges();
		}
	}
}