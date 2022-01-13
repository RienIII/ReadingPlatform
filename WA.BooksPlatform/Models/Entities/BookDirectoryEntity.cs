using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataValidator;

namespace WA.BooksPlatform.Models.Entities
{
	/// <summary>
	/// 書籍目錄 第幾卷
	/// </summary>
	public class BookDirectoryEntity
	{
		public int Id { get; set; }

		private string _Name;
		public string Name
		{
			get => _Name; 
			set
			{
				new DataValid<string>(value, "第幾卷").StringRequired().StringLengthGreaterOrEqualThan(3);
				_Name = value;
			}
		}

		public List<BookContentEntity> _Contents;
		public List<BookContentEntity> Contents
		{
			get => _Contents;
			set => _Contents = value == null ? null : value;
		}

		/// <summary>
		/// 每一卷 字數
		/// </summary>
		public int SubTotal
		{
			get => Contents.Sum(x=>x.WordCount);
			
		}

		public DateTime CreateTime { get; set; }
	}
}