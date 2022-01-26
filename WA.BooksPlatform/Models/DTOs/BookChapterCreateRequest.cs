using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.DTOs
{
	public class BookChapterCreateRequest
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Artical { get; set; }
		public int WordCount { get; set; }
		public DateTime? CreateTime { get; set; }
	}
}