using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.ViewModels
{
	public class MessageBoardCreateVM
	{
		[Display(Name = "標題")]
		[Required(ErrorMessage = "必填")]
		[StringLength(50)]
		public string Title { get; set; }

		[Display(Name = "評論")]
		[Required(ErrorMessage = "必填")]
		[StringLength(1000)]
		public string Chapter { get; set; }
	}
	public class MessageBoardItemCreateVM
	{
		[Display(Name = "留言內容")]
		[Required(ErrorMessage = "必填")]
		[StringLength(1000)]
		public string Chapter { get; set; }
	}
}