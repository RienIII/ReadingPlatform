using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.ViewModels
{
	public class RegisterVM
	{
		
		public int Id { get; set; }
		
		[Display(Name = "帳號")]
		[Required(ErrorMessage = "必填")]
		[StringLength(50)]
		public string Account { get; set; }

		[Display(Name = "密碼")]
		[Required(ErrorMessage = "必填")]
		[StringLength(50)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "確認密碼")]
		[Required(ErrorMessage = "必填")]
		[StringLength(50)]
		[DataType(DataType.Password)]
		[Compare(nameof(Password))]
		public string ConfirmPassword { get; set; }

		[Display(Name = "暱稱")]
		[Required(ErrorMessage = "必填")]
		[StringLength(50)]
		public string Name { get; set; }

		[Required(ErrorMessage = "必填")]
		[StringLength(256)]
		[EmailAddress]
		public string Email { get; set; }
	}
}