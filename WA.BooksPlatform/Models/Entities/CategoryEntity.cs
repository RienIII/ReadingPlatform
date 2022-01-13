using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataValidator;

namespace WA.BooksPlatform.Models.Entities
{
	public class CategoryEntity
	{
		public int Id { get; set; }

		private string _Name;
		public string Name
		{
			get => _Name;
			set
			{
				new DataValid<string>(value, "分類名稱").StringRequired();
				_Name = value;
			}
		}

		private int _DisplayOrder;
		public int DisplayOrder
		{
			get => _DisplayOrder;
			set
			{
				new DataValid<int>(value, "顯示順序").GreaterThan(0);
				_DisplayOrder = value;
			}
		}
	}
}