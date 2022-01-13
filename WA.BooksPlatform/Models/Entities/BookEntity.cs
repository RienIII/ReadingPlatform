using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.Entities
{
	/// <summary>
	/// 書籍
	/// </summary>
	public class BookEntity
	{
		public BookEntity()
		{

		}
		public int Id { get; set; }
		public string Name { get; set; }
		public string Writer { get; set; }
		// 簡介
		public string Introduction { get; set; }

		// 分類
		public CategoryEntity Category { get; set; }

		private List<BookDirectoryEntity> Items;

		public int TotalWord => Items == null ? 0 : Items.Sum(x => x.SubTotal);
		public DateTime ModifiedTime { get; set; }
	}
}