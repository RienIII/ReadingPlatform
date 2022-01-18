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
		public string Name
		{
			get => _Name;
			set
			{
				new DataValid<string>(value, "章節名稱").StringRequired().StringLengthLessThan(50);
				_Name = value;
			}
		}

		private string _Content;
		public string Content
		{
			get => _Content;
			set
			{
				new DataValid<string>(value, "內容").StringRequired().StringLengthGreaterThan(500);
				_Content = value;
			}
		}
		public int WordCount => string.IsNullOrEmpty(Content) ? 0 : Content.Length;
		
	}
}