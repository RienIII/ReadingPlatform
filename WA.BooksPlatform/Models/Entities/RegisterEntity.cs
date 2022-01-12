using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Entities
{
	public class RegisterEntity
	{
		public int Id { get; set; }
		public string Account { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string ConfirmCode { get; set; }
	}
}