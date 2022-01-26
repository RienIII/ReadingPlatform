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
        private AuthorService authorService;
		public AuthorsController()
		{
            bookRepo = new BookRepository(db);
            memberRepo = new MemberRepository(db);
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
            return View(model);
        }
    }
}