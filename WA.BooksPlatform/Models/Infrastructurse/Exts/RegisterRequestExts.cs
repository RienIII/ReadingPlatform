using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Entities;
using WA.BooksPlatform.Models.DTOs;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class RegisterRequestExts
	{
		public static MemberEntity ToEntity(this RegisterRequest request, string confirmCode)
			=>new MemberEntity(
				request.Account, 
				request.Name, 
				request.Email, 
				request.Password, 
				confirmCode);
		
	}
}