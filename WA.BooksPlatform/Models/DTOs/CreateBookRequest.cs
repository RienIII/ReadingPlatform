using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.DTOs
{
	public class CreateBookRequest
	{
		public string Name { get; set; }

		public string Blurb { get; set; }

		public string ImageFilaName { get; set; }
	}
}