using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.Infrastructurse
{
	public class ForPages
	{
		/// <summary>
		/// 預設頁數
		/// </summary>
		public ForPages()
		{
			this.NowPage = 1;
		}

		/// <summary>
		/// 如果有給值，則以值為主
		/// </summary>
		/// <param name="page"></param>
		public ForPages(int page)
		{
			this.NowPage = page;
		}

		/// <summary>
		/// 目前頁數
		/// </summary>
		public int NowPage { get; set; }

		/// <summary>
		/// 最大頁數
		/// </summary>
		public int MaxPage { get; set; }

		/// <summary>
		/// 頁數個數
		/// </summary>
		public int ItemNumPage => 10;

		public void SetPage()
		{
			if (this.NowPage < 1) this.NowPage = 1;
			if (this.NowPage > MaxPage) this.NowPage = MaxPage;
			if (this.MaxPage.Equals(0)) this.NowPage = 1;
		}
	}
}