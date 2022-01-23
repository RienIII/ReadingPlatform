using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.ViewModels
{
	public class ForgetPasswordVM
	{
		[Display(Name = "帳號")]
		[Required(ErrorMessage = "必填")]
		[StringLength(50)]
		public string Account { get; set; }

		[Required(ErrorMessage = "必填")]
		[StringLength (256)]
		[EmailAddress]
		public string Email { get; set; }
	}
	public class ForgetPasswordResetVM
	{
		[Display (Name = "密碼")]
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
	}
}