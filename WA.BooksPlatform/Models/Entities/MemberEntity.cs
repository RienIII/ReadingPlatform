using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataValidator;
using HashUtilities;

namespace WA.BooksPlatform.Entities
{
	public class MemberEntity : MemberEntityNoPassword
	{
		public MemberEntity(string account, string name, string email, string password) 
			: base(account, name, email)
		{
			new DataValid<string>(password, "密碼").StringRequired().StringLengthLessThan(100);

			this.Password = password;
		}
		public MemberEntity(string account, string name, string email, string password, string confirmCode):this(account, name, email, password)
		{
			IsConfirmed = false;
			this.ConfirmCode= confirmCode;
		}
		public string Password { get; set; }

		public string EnctryptedPassword
		{
			get
			{
				string salt = SALT;
				string result = HashUtility.ToSHA256(Password, salt);

				return result;
			}
		}
	}
	public class MemberEntityNoPassword
	{
		public MemberEntityNoPassword(string account, string name, string email)
		{
			new DataValid<string>(account, "帳號").StringRequired().StringLengthLessThan(50);
			new DataValid<string>(name, "暱稱").StringRequired().StringLengthLessThan(50);
			new DataValid<string>(email, "Email").StringRequired().StringLengthLessThan(256);

			this.Account = account;
			this.Name = name;
			this.Email = email;
		}
		public MemberEntityNoPassword(int id, string account, string name, string email, bool isConfirmed, string confirmCode):this(account, name, email)
		{
			this.Id = id;
			this.IsConfirmed = isConfirmed;
			this.ConfirmCode = confirmCode;
		}

		public const string SALT = "!@#$%^&";
		public int Id { get; set; }

		public string Account { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		private string _ImageFileName;
		public string ImageFileName
		{
			get => _ImageFileName;
			set => _ImageFileName = string.IsNullOrEmpty(value) ? string.Empty : value;
		}

		public bool IsConfirmed { get; set; }

		public string ConfirmCode { get; set; }
	}
}