using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.DTOs
{
	public class BecomeAuthorRequest
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Author { get; set; }
		public int MemberId { get; set; }
	}
}