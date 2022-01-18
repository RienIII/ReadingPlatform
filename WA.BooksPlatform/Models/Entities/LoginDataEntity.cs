using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Entities
{
	/// <summary>
	/// 登入、註冊等，資料傳遞
	/// </summary>
	public class LoginDataEntity
	{
		public int Id { get; set; }
		public string Account { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string ConfirmCode { get; set; }
		public string Role { get; set; }

	}
}