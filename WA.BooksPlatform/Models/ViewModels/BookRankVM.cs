using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse;

namespace WA.BooksPlatform.Models.ViewModels
{
	public class BookRankVM
	{
		public List<BookBasicEntity> Books { get; set; }

		/// <summary>
		/// 排序方式
		/// </summary>
		public string Sort { get; set; }

		/// <summary>
		/// 分頁
		/// </summary>
		public ForPages ForPages { get; set; }
	}
}