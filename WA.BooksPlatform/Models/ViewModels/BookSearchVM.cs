using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse;

namespace WA.BooksPlatform.Models.ViewModels
{
	/// <summary>
	/// 進入搜尋頁用
	/// </summary>
	public class BookSearchVM
	{
		/// <summary>
		/// 呈現書籍
		/// </summary>
		public List<BookBasicEntity> Books { get; set; }

		/// <summary>
		/// 搜尋條件
		/// </summary>
		public string Search { get; set; }

		/// <summary>
		/// 根據分類ID尋找
		/// </summary>
		public int? CategoryId { get; set; }
		public List<CategoryEntity> Category { get; set; }

		/// <summary>
		/// 分頁
		/// </summary>
		public ForPages ForPages { get; set; }
	}
}