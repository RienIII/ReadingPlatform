using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WA.BooksPlatform.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index(int bookId)
        {
            return View();
        }
    }
}