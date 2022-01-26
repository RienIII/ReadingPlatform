using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse;

namespace WA.BooksPlatform.Models.ViewModels
{
	/// <summary>
	/// 作者書籍顯示用
	/// </summary>
	public class ManageAuthorBooksVM
	{
		/// <summary>
		/// 作者書籍
		/// </summary>
		public List<BookBasicEntity> Books { get; set; }
		/// <summary>
		/// 分頁用
		/// </summary>
		public ForPages ForPages { get; set; }
	}
}