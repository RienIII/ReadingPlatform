using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HashUtilities;
using WA.BooksPlatform.Entities;

namespace WA.BooksPlatform.Models.DTOs
{
	public class LoginRequest
	{
		public string Account { get; set; }
		public string Password { get; set; }
		public string EnctryptedPassword
		{
			get
			{
				string salt = MemberEntity.SALT;
				string result = HashUtility.ToSHA256(Password, salt);
				return result;
			}
		}
	}
}