﻿using System;
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

			if (entity.CategoryId.HasValue) query = query.Where(x => x.CategoryId == entity.CategoryId);
			if (!string.IsNullOrEmpty(entity.BookName))query = query.Where(x => x.Name.Contains(entity.BookName));
			if (entity.Status.HasValue) query = query.Where(x => x.Status == entity.Status);

			if(entity.ForPages == null)
			{
				var books = query.Take(entity.TakeCount).ToList().Select(x => x.ToEntity());

				return books.ToList();
			}

			var booksPages = query.ToList().Select(x=>x.ToEntity());

			return ForPages(entity.ForPages, booksPages);
		}
		/// <summary>
		/// 分頁用，全部寫在Search感覺好長
		/// </summary>
		/// <param name="pages">因為要分頁，所以要給分頁資訊</param>
		/// <param name="entity">書籍基本訊息</param>
		/// <returns></returns>
		static List<BookBasicEntity> ForPages(ForPages pages, IEnumerable<BookBasicEntity> entity)
		{
			pages.MaxPage = Convert.ToInt32
			(
				Math.Ceiling
				(
					Convert.ToDouble(entity.Count() / pages.ItemNumPage)
				)
			);

			pages.SetPage();

			return entity
				.OrderBy(x => x.Name)
				.Skip((pages.NowPage - 1) * pages.ItemNumPage)
				.Take(pages.ItemNumPage)
				.ToList();
		}
	}
}