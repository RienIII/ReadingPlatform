using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.ViewModels
{
	public class BookChapter
	{
		public int Id { get; set; }
		/// <summary>
		/// 章節標題
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// 文章內容
		/// </summary>
		public string Artical { get; set; }
		public int WordCount => string.IsNullOrEmpty(Artical) ? 0 : Artical.Length;
	}
}