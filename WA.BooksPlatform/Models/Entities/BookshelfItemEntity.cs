using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.Entities
{
	/// <summary>
	/// 書架的書籍項目
	/// </summary>
	public class BookshelfItemEntity
	{
		public int Id { get; set; }

		private BookBasicEntity _Book;
		public BookBasicEntity Book
		{
			get => _Book;
			set => this._Book = value == null ? throw new Exception("新增的書籍不能是NULL") : value;
		}
		public int TotalWord => Book.TotalWord;
		public DateTime WatchTime { get; set; }
	}
}