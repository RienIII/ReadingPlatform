using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse;

namespace WA.BooksPlatform.Models.ViewModels
{
	/// <summary>
	/// 呈現書架用
	/// </summary>
	public class BookshelfVM
	{
		public BookshelfEntity Books { get; set; }
		public ForPages ForPages { get; set; }
	}
}