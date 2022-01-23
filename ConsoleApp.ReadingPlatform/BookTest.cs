using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse.Repositories;
using WA.BooksPlatform.Models.Services.Core;
using WA.BooksPlatform.Models.Services.Core.Interfaces;

namespace ConsoleApp.ReadingPlatform
{
	public class BookTest
	{
		private IBookRepository bookSearchRepo = new BookSearchRepository();
		private IBookRepository bookRankRepo = new BookRankRepository();
		private IBookNoSearchRepository bookHomeRepo = new BookHomeRepository();
		private BookService service;

		/// <summary>
		/// 點開書籍時會呈現的畫面
		/// </summary>
		public void Lord()
		{
			service = new BookService(bookSearchRepo, bookHomeRepo);

			BookEntity book = service.AppearBook(1);
		}
		/// <summary>
		/// 首頁會呈現的熱門書籍畫面
		/// </summary>
		public void Current()
		{
			BookRepositoryEntity entity = new BookRepositoryEntity
			{
				BookName = null,
				CategoryId = null,
				ForPages = null,
				Status = true,
				TakeCount = 4,
			};
			service = new BookService(bookSearchRepo, bookHomeRepo);

			var books = service.Current(entity);
		}
		/// <summary>
		/// 首頁的最近更新書籍
		/// </summary>
		public void GetLatest()
		{
			var books = service.CurrentLatestUpdate();
		}
	}
}
