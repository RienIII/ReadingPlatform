using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataValidator;

namespace WA.BooksPlatform.Models.Entities
{
	/// <summary>
	/// 作者資訊
	/// </summary>
	public class AuthorEntity
	{
		public int Id { get; set; }

		private string _Name;
		public string Name
		{
			get => _Name;
			set
			{
				new DataValid<string>(value, "名稱").StringRequired().StringLengthGreaterThan(0).StringLengthLessThan(50);
				_Name = value;
			}
		}
		public int? MemberId { get; set; }
	}
}