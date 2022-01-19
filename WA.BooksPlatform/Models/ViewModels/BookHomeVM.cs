using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.ViewModels
{
	/// <summary>
	/// 首頁用 ViewModels
	/// </summary>
	public class BookHomeVM
	{
		/// <summary>
		/// 熱門推薦書籍
		/// </summary>
		public List<BookBasicEntity> PopularBooks { get; set; }

		/// <summary>
		/// 最近更新書籍
		/// </summary>
		public List<BookBasicEntity> LatestUpdateBooks { get; set; }

		/// <summary>
		/// 搜尋
		/// </summary>
		public string Search { get; set; }
	}
}