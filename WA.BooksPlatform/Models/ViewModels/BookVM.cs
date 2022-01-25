using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.ViewModels
{
	public class BookVM
	{
		public int Id { get; set; }
		/// <summary>
		/// 封面圖
		/// </summary>
		public string ImageFileName { get; set; }

		/// <summary>
		/// 書名
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 作者
		/// </summary>
		public string Author { get; set; }

		/// <summary>
		/// 簡介
		/// </summary>
		public string Blurb { get; set; }
		public string BirefBlurb
		{
			get
			{
				if (string.IsNullOrEmpty(Blurb))return string.Empty;

				int maxLength = 15;

				return Blurb.Length > maxLength ? Blurb.Substring(0, maxLength) : Blurb;
			}
		}

		private CategoryEntity _Category;
		/// <summary>
		/// 書籍分類
		/// </summary>
		public CategoryEntity Category
		{
			get => _Category;
			set => _Category = value == null ? null : value;
		}

		public BookChapterVM Chapter;
		/// <summary>
		/// 書籍狀態 1=上架；2=付費書籍；3=下架
		/// </summary>
		public bool Status { get; set; }

		/// <summary>
		/// 總字數
		/// </summary>
		public int TotalWord => Chapter.Chapter == null ? 0 : Chapter.Chapter.Sum(x => x.WordCount);

		/// <summary>
		/// 異動日期
		/// </summary>
		public DateTime ModifiedTime { get; set; }

		/// <summary>
		/// 點擊數
		/// </summary>
		public int Clicks { get; set; }

		/// <summary>
		/// 按讚數
		/// </summary>
		public int Likes { get; set; }

		/// <summary>
		/// 收藏數
		/// </summary>
		public int Collection { get; set; }
	}
}