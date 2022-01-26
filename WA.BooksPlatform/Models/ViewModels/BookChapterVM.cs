using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse;

namespace WA.BooksPlatform.Models.ViewModels
{
	public class BookChapterVM
	{
		public List<BookChapterItemVM> Chapter { get; set; }
		public ForPages ForPages { get; set; }
	}
}