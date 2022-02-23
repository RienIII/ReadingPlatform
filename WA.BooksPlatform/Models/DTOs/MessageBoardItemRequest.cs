using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.DTOs
{
	public class MessageBoardItemRequest
	{
		public int MessageBoardId { get; set; }
		public int MemberId { get; set; }
		public string Chapter { get; set; }
	}
}