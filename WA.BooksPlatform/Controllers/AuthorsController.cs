using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WA.BooksPlatform.Models.DTOs;
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
    [Authorize(Roles = "Author")]
    public class AuthorsController : Controller
    {
        AppDbContext db = new AppDbContext();
        private IBookRepository bookRepo;
        private IMemberRepository memberRepo;
        private ICategoryRepository categoryRepo;
        private AuthorService authorService;
		public AuthorsController()
		{
            bookRepo = new BookRepository(db);
            memberRepo = new MemberRepository(db);
            categoryRepo = new CategoryRepository(db);
            authorService = new AuthorService(bookRepo, memberRepo);
		}

        public ActionResult Index(int pages = 1)
        {
            ManageAuthorBooksVM model = new ManageAuthorBooksVM { ForPages = new ForPages(pages) };

            var authorId = memberRepo.Lord(User.Identity.Name).Author.Id;

            BookRepositoryEntity entity = new BookRepositoryEntity
			{
                AuthorId = authorId,
                Status = true,
                ForPages = model.ForPages
			};

            model.Books = bookRepo.Search(entity);

            return View(model);
        }

        public ActionResult BookCreate()
		{
            ViewBag.Category = categoryRepo.Search(null);

            return View();
		}
        [HttpPost]
        public ActionResult BookCreate(ManageAuthorBookCreateVM model, HttpPostedFileBase file)
        {
            if(!ModelState.IsValid)return View(model);
            
            CreateBookResponse response = authorService.BookCreate(model.ToRequest(), User.Identity.Name);

            if (response.IsSuccess)
			{
                return RedirectToAction("Index", "Authors");
			}

            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            ViewBag.Category = categoryRepo.Search(null);
            return View(model);
        }

        public ActionResult CurrentBookChapter(int bookId)
		{
            string author = memberRepo.Lord(User.Identity.Name).Author.Name;

            var book = bookRepo.Lord(bookId, true).ToVM();
            if(book.Author == author)
			{
                return View(book);
			}
            book = null;
            return View(book);
		}

        public ActionResult BookChapterCreate(int bookId)
		{
            ViewBag.BookId = bookId;

            return View();
		}
		[HttpPost]
		public ActionResult BookChapterCreate(int bookId, BookChapterItemVM model)
		{
            if (!ModelState.IsValid) return View(model);

            model.Artical = model.Artical.Replace("\r\n", "</p><p>&emsp;&emsp;");
            CreateBookResponse response = authorService.BookChapterCreate(model.ToRequest(), bookId);

			if (response.IsSuccess)
			{
                return RedirectToAction("CurrentBookChapter", new {bookId = bookId});
			}

            ModelState.AddModelError(string.Empty, response.ErrorMessage);
			return View(model);
		}

        public ActionResult BookChapterEdit(int bookId, int chapterId)
		{
            ViewBag.BookId = bookId;

            BookChapterItemVM model = bookRepo.Lord(bookId, true).ToBookChapterItemVM(chapterId);

            model.Artical = model.Artical.Replace("</p><p>&emsp;&emsp;", "\r\n");

            return View(model);
		}

        [HttpPost]
        public ActionResult BookChapterEdit(int bookId, int chapterId, BookChapterItemVM model)
        {
            if(!ModelState.IsValid)return View(model);

            model.Artical = model.Artical.Replace("\r\n", "</p><p>&emsp;&emsp;");
            CreateBookResponse response = authorService.BookChapterEdit(model.ToRequest(), chapterId);

			if (response.IsSuccess)
			{
                return RedirectToAction("CurrentBookChapter", new { bookId = bookId });
            }

            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View(model);
        }
    }
}