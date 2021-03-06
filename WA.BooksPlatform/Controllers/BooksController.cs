using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WA.BooksPlatform.Models.Infrastructurse;
using WA.BooksPlatform.Models.Infrastructurse.Exts;
using WA.BooksPlatform.Models.Infrastructurse.Repositories;
using WA.BooksPlatform.Models.Services.Core;
using WA.BooksPlatform.Models.Services.Core.Interfaces;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Controllers
{
    public class BooksController : Controller
    {

        IBookRepository bookRepo;
        IBookNoSearchRepository bookNoSearchRepo;
        BookService bookService;
		public BooksController()
		{
            this.bookRepo = new BookRepository();
            this.bookNoSearchRepo = new BookHomeRepository();
		}

        /// <summary>
        /// 點開書籍會呈現書籍資料
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public ActionResult Index(int bookId)
        {
            return View(LordBook(bookId));
        }

        [Authorize]
        /// <summary>
        /// 點開目錄會看到 有哪些章節
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public ActionResult ChooseChapter(int bookId)
        {
            var template = new ChapterLink("<a href=\"/Books/Chapter?bookId={0}&pages={1}\" class=\"btn btn-default\">{2}</a>");
            ViewBag.ChapterLink = template;

            return View(LordBook(bookId));
        }

        [Authorize(Roles = "General,VIP")]
        /// <summary>
        /// 呈現章節內容
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public ActionResult Chapter(int bookId, int pages = 1)
		{
            BookVM model = new BookVM();

            model = LordBook(bookId);
            model.Chapter.ForPages = new ForPages(pages);
            model.Chapter.Chapter = ChapterPages(model.Chapter, model.Chapter.ForPages); // 呼叫ChapterPages(章節內容分頁)進行分頁工作

            var template = new ChapterLink("<p>&emsp;&emsp;{0}</p>");
            ViewBag.Template = template;

            return View(model);
        }
        private BookVM LordBook(int bookId)
		{
            bookService = new BookService(bookRepo, bookNoSearchRepo);
            BookVM book = bookService.AppearBook(bookId).ToVM();

            return book;
        }
        private List<BookChapterItemVM> ChapterPages(BookChapterVM model, ForPages pages)
		{
            pages.MaxPage =
                Convert.ToInt32(
                    Math.Ceiling(
                        Convert.ToDouble(model.Chapter.Count() / pages.ChapterItemNumPage)
                    )
                );

            pages.SetPage();

            return model.Chapter.OrderBy(x => x.Id).Skip((pages.NowPage - 1) * pages.ChapterItemNumPage).Take(pages.ChapterItemNumPage).ToList();
        }
        public class ChapterLink
		{
			public string template { get; set; }
			public ChapterLink(string temp)
			{
                this.template = temp;
			}

            /// <summary>
            /// 選擇章節，所要呈現的超連接
            /// </summary>
            /// <param name="bookId">哪一本書籍</param>
            /// <param name="pages">頁數</param>
            /// <param name="chapterName">章節名稱</param>
            /// <returns></returns>
            public MvcHtmlString DisplayChapter(int bookId, int pages, string chapterName)
            {
                return new MvcHtmlString(string.Format(template, bookId, pages, chapterName));
            }

            /// <summary>
            /// 顯示內容，有文字置換
            /// </summary>
            /// <param name="artical"></param>
            /// <returns></returns>
            public MvcHtmlString DisplayChapter(string artical)
            {
                return new MvcHtmlString(string.Format(template, artical));
            }
        }
	}
}