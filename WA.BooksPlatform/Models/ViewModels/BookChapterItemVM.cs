using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.ViewModels
{
	public class BookChapterItemVM
	{
		public int Id { get; set; }

		/// <summary>
		/// 章節標題
		/// </summary>
		[Display(Name = "章節名稱")]
		[Required(ErrorMessage = "必填")]
		[StringLength(50)]
		public string Name { get; set; }


		/// <summary>
		/// 文章內容
		/// </summary>
		[Display(Name = "內容")]
		[Required(ErrorMessage = "必填")]
		public string Artical { get; set; }
		public int WordCount => string.IsNullOrEmpty(Artical) ? 0 : Artical.Length;
		public DateTime? CreateTime { get; set; }
	}
}