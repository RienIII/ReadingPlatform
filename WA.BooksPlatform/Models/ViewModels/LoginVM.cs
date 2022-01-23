using HashUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Entities;
using WA.BooksPlatform.Models.DTOs;

namespace WA.BooksPlatform.Models.ViewModels
{
	public class LoginVM
	{
		[Display(Name = "帳號")]
		[Required(ErrorMessage = "必填")]
		[StringLength(50)]
		public string Account { get; set; }
		[Display(Name = "密碼")]
		[Required(ErrorMessage = "必填")]
		[StringLength(50)]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}