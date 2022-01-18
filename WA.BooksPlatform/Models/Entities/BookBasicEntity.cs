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
		public string Name { get; set; }
		public string Author { get; set; }
		public int TotalWord { get; set; }
		public string Blurb { get; set; }
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
	}
}