using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.Entity;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Services.Core.Interfaces;
using WA.BooksPlatform.Models.Infrastructurse.Exts;
using System.Data.SqlClient;

namespace WA.BooksPlatform.Models.Infrastructurse.Repositories
{
	public class BookshelfRepository : IBookshelfRepository
	{
		private readonly string connStr = System.Configuration
												.ConfigurationManager
												.ConnectionStrings["AppDbContext"]
												.ToString();
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
			int count = GetBookshelfItemCount(entity.Id);

			List<BookshelfItem> items = new List<BookshelfItem>();

			if (count > 0)
			{
				DeleteBookshelfItem(entity.Id);
				
				foreach (var item in entity.Books)
				{
					items.Add(new BookshelfItem { BookId = item.Book.Id, BookshelfId = entity.Id});
				}
				InsertBookshelfItem(entity.Id, items);
				return;
			}

			foreach (var item in entity.Books)
			{
				items.Add(new BookshelfItem { BookId = item.Book.Id, BookshelfId = entity.Id });
			}
			InsertBookshelfItem(entity.Id, items);
		}
		private void DeleteBookshelfItem(int bookshelfId)
		{
			string sql = @"delete from BookshelfItems where BookshelfId = @BookshelfId";
			var data = new { BookshelfId = bookshelfId };
			using (var conn = new SqlConnection(connStr))
			{
				conn.Execute(sql, data);
			}
		}
		private void InsertBookshelfItem(int bookshelfId, List<BookshelfItem> items)
		{
			string sql = @"insert into BookshelfItems(BookId, BookshelfId)values(@BookId, @BookshelfId)";
			List<BookshelfItem> bookshelfItems = items;
			using (var conn = new SqlConnection(connStr))
			{
				conn.Execute(sql, bookshelfItems);
			}
		}
		private int GetBookshelfItemCount(int bookshelfId)
		{
			string sql = @"select BookshelfId from BookshelfItems where BookshelfId=@BookshelfId";
			var bookshelf = new { BookshelfId = bookshelfId };

			int count = 0;
			using (var conn = new SqlConnection(connStr))
			{
				count = conn.Query<BookshelfItem>(sql, bookshelf).ToList().Count;
			}

			return count;
		}
	}
}