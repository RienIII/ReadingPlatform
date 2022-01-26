using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.Infrastructurse;

namespace WA.BooksPlatform.Models.Entities
{
	/// <summary>
	/// 給Repository用的資料
	/// </summary>
	public class BookRepositoryEntity
	{
		/// <summary>
		/// 用作者ID尋找對應的書籍
		/// </summary>
		public int? AuthorId { get; set; }
		/// <summary>
		/// 分類ID
		/// </summary>
		public int? CategoryId { get; set; }
		/// <summary>
		/// 要搜尋的書名
		/// </summary>
		public string BookName { get; set; }
		/// <summary>
		/// 書籍當前狀態，true上架；false下架
		/// </summary>
		public bool? Status { get; set; }
		/// <summary>
		/// 要抓幾個值，因為書籍有很多，全部抓出來再挑有點蠢
		/// </summary>
		public int TakeCount { get; set; }
		/// <summary>
		/// 分頁用
		/// </summary>
		public ForPages ForPages { get; set; }
	}
}