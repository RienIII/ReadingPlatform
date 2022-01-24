using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.ViewModels
{
	public class ResetPasswordVM
	{
		[Display(Name = "原始密碼")]
		[StringLength(50)]
		[Required(ErrorMessage = "必填")]
		[DataType(DataType.Password)]
		public string OriginalPassword { get; set; }

		[Display(Name = "新密碼")]
		[StringLength(50)]
		[Required(ErrorMessage = "必填")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "確認密碼")]
		[StringLength(50)]
		[Required(ErrorMessage = "必填")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password))]
		public string ConfirmPassword { get; set; }
	}
}