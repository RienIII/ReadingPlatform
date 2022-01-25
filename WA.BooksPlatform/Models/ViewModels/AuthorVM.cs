using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.ViewModels
{
	public class AuthorVM
	{
		public int Id { get; set; }

		[Display(Name = "作者名稱")]
		[StringLength(50)]
		[Required]
		public string Name { get; set; }
		public int MemberId { get; set; }
	}
}