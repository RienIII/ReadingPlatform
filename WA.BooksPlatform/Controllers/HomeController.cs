using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse;
using WA.BooksPlatform.Models.Infrastructurse.Repositories;
using WA.BooksPlatform.Models.Services.Core;
using WA.BooksPlatform.Models.Services.Core.Interfaces;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Controllers
{
	public class HomeController : Controller
	{
		private AppDbContext db = new AppDbContext();
		private IBookRepository bookRepo, bookRankRepo, bookSearchRepo;
		private IBookHomeRepository bookHomeRepo;
		private ICategoryRepository categoryRepo;
		private IMemberRepository memberRepo;
		private IBookshelfRepository bookshelfRepo;
		private BookService bookService;

		public HomeController()
		{
			this.bookRepo = new BookRepository(db);
			this.bookHomeRepo = new BookHomeRepository(db);
			this.bookRankRepo = new BookRankRepository(db);
			this.bookSearchRepo = new BookSearchRepository(db);
			this.categoryRepo = new CategoryRepository(db);
			this.memberRepo = new MemberRepository(db);
			this.bookshelfRepo = new BookshelfRepository(db);
		}
		/// <summary>
		/// 首頁
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			BookHomeVM model = new BookHomeVM() { };
			bookService = new BookService(bookRepo, bookHomeRepo);
			BookRepositoryEntity entity = new BookRepositoryEntity
			{
				Status = true,
				TakeCount = 3
			};

			model.PopularBooks = bookService.Current(entity);
			model.LatestUpdateBooks = bookService.CurrentLatestUpdate();

			return View(model);
		}

		public ActionResult Category()
		{
			return View(categoryRepo.Search(null));
		}
		public ActionResult CategoryBooks(int? categoryId, string search, int pages = 1)
		{
			BookSearchVM model = new BookSearchVM()
			{
				CategoryId = categoryId,
				ForPages = new ForPages(pages),
				Search = search
			};

			BookRepositoryEntity entity = new BookRepositoryEntity
			{
				CategoryId = categoryId,
				BookName = search,
				Status = true,
				ForPages = model.ForPages
			};

			bookService = new BookService(bookSearchRepo, bookHomeRepo);
			model.Books = bookService.Current(entity);

			return View(model);
		}
		[Authorize]
		public ActionResult Bookshelf(int pages = 1)
		{
			BookshelfService service = new BookshelfService(bookshelfRepo, bookRepo);
			BookshelfVM model = new BookshelfVM { ForPages = new ForPages(pages) };

			int userId = memberRepo.Lord(User.Identity.Name).Id;

			model.Books = service.CurrentBookshelf(model.ForPages, userId);

			return View(model);
		}
		[Authorize]
		public ActionResult AddItem2Bookshelf(int bookId)
		{
			BookshelfService service = new BookshelfService(bookshelfRepo, bookRepo);
			int userId = memberRepo.Lord(User.Identity.Name).Id;
			service.AddItem(userId, bookId);

			return new EmptyResult();
		}
		public ActionResult DelectItem2Bookshelf(int bookId)
		{
			BookshelfService service = new BookshelfService(bookshelfRepo, bookRepo);
			int userId = memberRepo.Lord(User.Identity.Name).Id;

			service.RemoveItem(userId, bookId);

			return new EmptyResult();
		}
		public ActionResult Rank(int rankId = 1)
		{
			BookRepositoryEntity entity = new BookRepositoryEntity
			{
				Status = true,
				TakeCount = 10
			};
			var books = bookRankRepo.Search(entity);

			switch (rankId)
			{
				case 1:
					books = books.OrderBy(x => x.Collections).ToList();
					break;
				case 2:
					books = books.OrderBy(x => x.Likes).ToList();
					break;
			}

			return View();
		}
	}
}