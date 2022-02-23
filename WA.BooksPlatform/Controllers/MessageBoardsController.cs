using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Infrastructurse;
using WA.BooksPlatform.Models.Infrastructurse.Exts;
using WA.BooksPlatform.Models.Infrastructurse.Repositories;
using WA.BooksPlatform.Models.Services.Core;
using WA.BooksPlatform.Models.Services.Core.Interfaces;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Controllers
{
    [Authorize]
    public class MessageBoardsController : Controller
    {
        private AppDbContext db = new AppDbContext();
        private IMessageBoardRepository messageBoardRepo;
        private IMemberRepository memberRepo;
        private MessageBoardService service;
		public MessageBoardsController()
		{
            this.messageBoardRepo = new MessageBoardRepository(db);
            this.memberRepo = new MemberRepository(db);
            this.service = new MessageBoardService(messageBoardRepo);
		}

        [AllowAnonymous]
        public ActionResult Index(int bookId, int pages = 1)
        {
            MessageBoardIndexVM model = new MessageBoardIndexVM { ForPages = new ForPages(pages) };

            model.MessageBoard = messageBoardRepo.Search(bookId, model.ForPages);

            ViewBag.BookId = bookId;
            var template = new DisplayChapterHtml("<p>&emsp;&emsp;{0}</p>");
            ViewBag.ChapterHtml = template;

            return View(model);
        }
        public ActionResult MessageBoardCreate(int bookId = 1)
        {
            ViewBag.BookId = bookId;
            return View();
        }
        [HttpPost]
        public ActionResult MessageBoardCreate(MessageBoardCreateVM model, int bookId = 1)
		{
            if(!ModelState.IsValid)return View(model);

            int memberId = memberRepo.LordMemberId(User.Identity.Name);
            model.Chapter = model.Chapter.Replace("\r\n", "</p><p>&emsp;&emsp;");
            CommonResponse response = service.CreateMessageBoard(model.ToRequest(bookId, memberId));

			if (response.IsSuccess)
			{
                return RedirectToAction("Index", new { bookId = bookId, pages = 1 });
			}

            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View(model);
		}
        public ActionResult MessageBoardItemIndex(int bookId, int messageBoardId)
		{
            MessageBoardItemIndexVM model = new MessageBoardItemIndexVM();

            model.MessageBoard = messageBoardRepo.Lord(messageBoardId);

            ViewBag.MessageBoardId = messageBoardId;
            ViewBag.BookId = bookId;
            var template = new DisplayChapterHtml("<p>&emsp;&emsp;{0}</p>");
            ViewBag.ChapterHtml = template;

            return View(model);
        }
        public ActionResult MessageBoardItemCreate(int messageBoardId)
		{
            ViewBag.BookId = messageBoardRepo.Lord(messageBoardId).BookId;
            ViewBag.MessageBoardId = messageBoardId;

            return View();
		}
        [HttpPost]
        public ActionResult MessageBoardItemCreate(int messageBoardId, MessageBoardItemCreateVM model)
        {
            if(!ModelState.IsValid)return View(model);

            int memberId = memberRepo.LordMemberId(User.Identity.Name);
            CommonResponse response = service.CreateMessageBoardItem(model.ToRequest(messageBoardId, memberId));

			if (response.IsSuccess)
			{
                return RedirectToAction
                (
                    "MessageBoardItemIndex", 
                    new 
                    { 
                        bookId = messageBoardRepo.Lord(messageBoardId).BookId, 
                        messageBoardId = messageBoardId
                    }
                );
			}

            
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View(model);
        }
        public class DisplayChapterHtml
		{
            private string Template;
			public DisplayChapterHtml(string temp)
			{
                this.Template = temp;
			}
            public MvcHtmlString ChapterHtml(string chapter)
			{
                return new MvcHtmlString(string.Format(Template, chapter));
			}
		}
    }
}