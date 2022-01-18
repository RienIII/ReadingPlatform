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
			if (Request.IsAuthenticated) // �|�ݧA���S���n�J
			{
				// ���o�ϥΪ̪� FormsIdentity
				FormsIdentity identity = (FormsIdentity)User.Identity;
				// �A���o�ϥΪ̪� FormsAuthenticationTicket �A���o�{�Ҳ�
				FormsAuthenticationTicket ticket = identity.Ticket; // �w�g�ѽX�F
				string role = ticket.UserData; // ���o�{�Ҳ��̭������

				IPrincipal currentUser =
					new GenericPrincipal(
						User.Identity,
						// �]���v���ڭ̪��v���O�Φr��A�ҥH�n�� Split �s���}�C �� ',' �j�}�A�]���O�r���ҥH�γ�޸�
						// �᭱���ѼƬO�A��A���r��O"Admin, ,Editor"�A���@�ӬO�Ū��A�|�۰ʧR��
						// �p�G�r��̭����Ů� ���O:"Admin, Editor"�A�n�O�o�� Trim �M���Ů�
						role.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

				Context.User = currentUser; // �s�� Context.User �A���᳣�i�H�o�� User
			}
		}
	}
	
}
