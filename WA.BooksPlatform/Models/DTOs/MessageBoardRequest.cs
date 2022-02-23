using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.DTOs
{
	public class MessageBoardRequest
	{
		public int BookId { get; set; }
		public int MemberId { get; set; }
		public string Title { get; set; }
		public string Chapter { get; set; }
	}
}