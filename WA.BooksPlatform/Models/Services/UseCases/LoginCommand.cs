using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WA.BooksPlatform.Entities;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.Services.Core.Interfaces;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Models.Services.UseCases
{
	public class LoginCommand
	{
		private IMemberRepository memberRepo;
		public LoginCommand(IMemberRepository repo)
		{
			this.memberRepo = repo;
		}
		/// <summary>
		/// 找會員的權限
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		private string LordRoles(string account)
		{
			MemberEntityNoPassword member = memberRepo.Lord(account);

			return member.Roles;
		}
		public string ProcessLogin(string account, bool rememberMe, out HttpCookie cookie)
		{
			// 取得使用者權限
			string role = LordRoles(account);

			// 將 userID, level 存到 cookie 中
			// 建立認證票
			FormsAuthenticationTicket ticket =
				new FormsAuthenticationTicket(
					1,                      // 版本別，沒用，之後都沒改過
					account,                // cookie 名稱
					DateTime.Now,           // 發行日
					DateTime.Now.AddDays(1),// 到期日
					rememberMe,             // 是否續存，eg:網頁關掉要不要連 cookie 一起關掉
					role,                   // 放資料的地方
					"/");                   // 放跟目錄，代表全部網站可以用(當然是自己的專案)，也可以在某一個網頁可以用，這樣就不是跟目錄了

			// 加密
			string value = FormsAuthentication.Encrypt(ticket);

			// 存入 cookie | 其實第一個參數取得 cookie 名稱就是上面的 ticket 的 cookie 名稱
			cookie = new HttpCookie(FormsAuthentication.FormsCookieName, value);

			// 導回目的地網頁
			string url = FormsAuthentication.GetRedirectUrl(account, true); // 第二個參數沒有意義，但是要寫

			return url;
		}
	}
}