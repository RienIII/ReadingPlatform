using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace WA.BooksPlatform
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
		protected void AppLication_AuthenticateRequest()
		{
			if (Request.IsAuthenticated) // 會看你有沒有登入
			{
				// 取得使用者的 FormsIdentity
				FormsIdentity identity = (FormsIdentity)User.Identity;
				// 再取得使用者的 FormsAuthenticationTicket ，取得認證票
				FormsAuthenticationTicket ticket = identity.Ticket; // 已經解碼了
				string role = ticket.UserData; // 取得認證票裡面的資料

				IPrincipal currentUser =
					new GenericPrincipal(
						User.Identity,
						// 因為權限我們的權限是用字串，所以要用 Split 存成陣列 用 ',' 隔開，因為是字元所以用單引號
						// 後面的參數是，當你的字串是"Admin, ,Editor"，有一個是空的，會自動刪掉
						// 如果字串裡面有空格 像是:"Admin, Editor"，要記得用 Trim 清掉空格
						role.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

				Context.User = currentUser; // 存到 Context.User ，之後都可以得到 User
			}
		}
	}
	
}
