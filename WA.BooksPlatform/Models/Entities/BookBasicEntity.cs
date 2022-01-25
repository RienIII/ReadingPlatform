using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.Entities
{
	/// <summary>
	/// 像是首頁、書架所呈現的書籍基本資料
	/// </summary>
	public class BookBasicEntity
	{
		public int Id { get; set; }
		public string ImageFileName { get; set; }
		/// <summary>
		/// 書名
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// 作者名稱
		/// </summary>
		public string Author { get; set; }
		public int TotalWord { get; set; }
		/// <summary>
		/// 簡介
		/// </summary>
		public string Blurb { get; set; }
		/// <summary>
		/// 只顯示15個字
		/// </summary>
		public string BirefBlurb
		{
			get
			{
				if (string.IsNullOrEmpty(Blurb)) return string.Empty;

				int maxLength = 15;

				return (this.Blurb.Length > maxLength)
					? this.Blurb.Substring(0, maxLength) + "..."
					: this.Blurb;
			}
		}
		public string Category { get; set; }
		/// <summary>
		/// 收藏數
		/// </summary>
		public int Collections { get; set; }
		public int Likes { get; set; }
		public int Clicks { get; set; }
		/// <summary>
		/// 異動日期
		/// </summary>
		public DateTime? ModifiedTime { get; set; }
	}
}