using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataValidator;

namespace WA.BooksPlatform.Models.Entities
{
	/// <summary>
	/// 分類
	/// </summary>
	public class CategoryEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int DisplayOrder { get; set; }
	}
}