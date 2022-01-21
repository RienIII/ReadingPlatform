using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataValidator;

namespace WA.BooksPlatform.Models.Entities
{
	/// <summary>
	/// 書籍內容 第幾章
	/// </summary>
	public class BookChapterEntity
	{
		public int Id { get; set; }

		private string _Name;
		/// <summary>
		/// 章節標題
		/// </summary>
		public string Name
		{
			get => _Name;
			set
			{
				new DataValid<string>(value, "章節名稱").StringRequired().StringLengthLessThan(50);
				_Name = value;
			}
		}

		private string _Artical;
		/// <summary>
		/// 文章內容
		/// </summary>
		public string Artical
		{
			get => _Artical;
			set
			{
				new DataValid<string>(value, "內容").StringRequired().StringLengthGreaterThan(0);
				_Artical = value;
			}
		}
		public int WordCount => string.IsNullOrEmpty(Artical) ? 0 : Artical.Length;
		
	}
}