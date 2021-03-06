using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse;
using WA.BooksPlatform.Models.Infrastructurse.Exts;
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

		/// <summary>
		/// 列出有哪些分類
		/// </summary>
		/// <returns></returns>
		public ActionResult Category()
		{
			return View(categoryRepo.Search(null));
		}

		/// <summary>
		/// 搜尋書籍，可以用分類、搜尋條件找書
		/// </summary>
		/// <param name="categoryId">分類ID</param>
		/// <param name="search">搜尋條件</param>
		/// <param name="pages">當前頁數</param>
		/// <returns></returns>
		public ActionResult CategoryBooks(int? categoryId, string search, int pages = 1)
		{
			var template = new CategoryLink("<a href=\"/Home/CategoryBooks?categoryId={0}&search={1}&pages={2}\" class=\"btn btn-default active\">{3}</a>");
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
			model.Category = categoryRepo.Search(null);

			ViewBag.CategoryLink = template;

			return View(model);
		}

		/// <summary>
		/// 書架，顯示書架
		/// </summary>
		/// <param name="pages">當前頁數</param>
		/// <returns></returns>
		[Authorize]
		public ActionResult Bookshelf(int pages = 1)
		{
			BookshelfService service = new BookshelfService(bookshelfRepo, bookRepo);
			BookshelfVM model = new BookshelfVM { ForPages = new ForPages(pages) };

			int userId = memberRepo.Lord(User.Identity.Name).Id;

			model.Books = service.CurrentBookshelf(model.ForPages, userId);

			return View(model);
		}

		/// <summary>
		/// 新增書籍到書架裡面
		/// </summary>
		/// <param name="bookId">要新增至書架的書籍ID</param>
		/// <returns></returns>
		[Authorize]
		public ActionResult AddItem2Bookshelf(int bookId)
		{
			BookshelfService service = new BookshelfService(bookshelfRepo, bookRepo);
			int userId = memberRepo.Lord(User.Identity.Name).Id;
			service.AddItem(userId, bookId);

			return new EmptyResult();
		}

		/// <summary>
		/// 選擇要移出書架的書籍，前提是要有在書架裡面
		/// </summary>
		/// <param name="bookId">要移出書架的書籍ID</param>
		/// <returns></returns>
		public ActionResult DelectItem2Bookshelf(int bookId)
		{
			BookshelfService service = new BookshelfService(bookshelfRepo, bookRepo);
			int userId = memberRepo.Lord(User.Identity.Name).Id;

			service.RemoveItem(userId, bookId);

			return new EmptyResult();
		}

		/// <summary>
		/// 顯示排行
		/// </summary>
		/// <param name="sort">排序方式</param>
		/// <returns></returns>
		public ActionResult Rank(string sort)
		{
			BookRankVM model = new BookRankVM();
			BookRepositoryEntity entity = new BookRepositoryEntity
			{
				Status = true,
				TakeCount = 10
			};
			model.Books = bookRankRepo.Search(entity);

			switch (sort)
			{
				case "收藏":
					model.Books = model.Books.OrderBy(x => x.Collections).ToList();
					break;
				case "按讚":
					model.Books = model.Books.OrderBy(x => x.Likes).ToList();
					break;
				case "點擊":
					model.Books = model.Books.OrderBy(x => x.Clicks).ToList();
					break;
			}

			return View(model);
		}
		public class CategoryLink
		{
			private string Template;
			public CategoryLink(string template)
			{
				this.Template = template;
			}

			/// <summary>
			/// 生成HTML
			/// </summary>
			/// <param name="categoryId">分類ID</param>
			/// <param name="categoryName">分類名稱</param>
			/// <param name="search">搜尋內容</param>
			/// <param name="pages">當下分頁頁數</param>
			/// <returns></returns>
			public MvcHtmlString Category(int?categoryId, string categoryName, string search, int pages = 1)
			{
				return new MvcHtmlString(string.Format(Template, categoryId, search, pages, categoryName));
			}
		}
	}
}