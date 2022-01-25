using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Infrastructurse.Exts;
using WA.BooksPlatform.Models.Infrastructurse.Repositories;
using WA.BooksPlatform.Models.Services.Core;
using WA.BooksPlatform.Models.Services.Core.Interfaces;
using WA.BooksPlatform.Models.Services.UseCases;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Controllers
{
    public class MembersController : Controller
    {
        private AppDbContext db = new AppDbContext();
        private IMemberRepository memberRepo;
        private MemberService memberService;

		public MembersController()
		{
            memberRepo = new MemberRepository(db);
            memberService = new MemberService(memberRepo);
		}

        /**************************** 註冊 ****************************/
        // GET: Members/Register
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVM model)
        {
            if(!ModelState.IsValid)return View(model);

            string urlTemplate = Request.Url.Scheme
                + "://"
                + Request.Url.Authority
                + Url.Content("~/")
                + "Members/RegisterConfirm?memberId={0}&confirmCode={1}";

            MemberCommand command = new MemberCommand(memberRepo);

            RegisterResponse response = command.Execute(model, urlTemplate);

			if (response.IsSuccess)
			{
                return RedirectToAction("ActiveRegister", "Members");
			}
			else
			{
                ModelState.AddModelError(string.Empty, response.ErrorMessage);
                return View(model);
			}
        }
        public ActionResult ActiveRegister()
		{
            return View();
		}
        public ActionResult RegisterConfirm(int memberId, string confirmCode)
		{
            bool isSuccess = true;
            memberService.AtiveRegister(memberId, confirmCode, out isSuccess);

            return View();
		}

        /**************************** 登入/登出/忘記密碼 ****************************/
        public ActionResult Login()
		{
            return View();
		}
        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid) return View(model);

            LoginResponse response = memberService.Login(model.ToRequest());

            if (!response.IsSuccess)
			{
                ModelState.AddModelError(string.Empty, response.ErrorMessage);
                return View(model);
			}
            LoginCommand command = new LoginCommand(memberRepo);

            HttpCookie cookie;
            string url = command.ProcessLogin(model.Account, false, out cookie);
            Response.Cookies.Add(cookie);

            return Redirect(url);
        }
        [Authorize]
        public ActionResult Logout()
		{
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Members");
		}

        /*輸入帳號與Email，寄信進行重設密碼*/
        public ActionResult ForgetPassword()
		{
            return View();
		}
        [HttpPost]
        public ActionResult ForgetPassword(ForgetPasswordVM model)
        {
            if (!ModelState.IsValid) return View(model);

            RegisterResponse response = memberService.ForgetPassword(model.Account, model.Email);

            ForgetPasswordCommand forget = new ForgetPasswordCommand();
            string urlTemplate = Request.Url.Scheme
                + "://"
                + Request.Url.Authority
                + Url.Content("~/")
                + "Members/ForgetPasswordReset?memberId={0}&resetPasswordCode={1}";
            if (response.IsSuccess)
			{
                forget.Execute(response, urlTemplate);
                return RedirectToAction("ForgetView", "Members");
			}

            ModelState.AddModelError(string.Empty,response.ErrorMessage);
            return View(model);
        }
        public ActionResult ForgetView()
		{
            return View();
		}
        public ActionResult ForgetPasswordReset(string memberId, string resetConfirmCode)
		{
            return View();
		}
        [HttpPost]
        public ActionResult ForgetPasswordReset(int memberId, string resetConfirmCode, ForgetPasswordResetVM model)
        {
            if(!ModelState.IsValid) return View(model);

            RegisterResponse response = 
                memberService
                .ForgetPassword(model.ToRequest(memberId, resetConfirmCode));

			if (response.IsSuccess)
			{
                return RedirectToAction("ForgetPasswordResetView", "Members");
			}
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View(model);
        }
        public ActionResult ForgetPasswordResetView()
		{
            return View();
		}

        /**************************** 會員中心 ****************************/
        [Authorize]
        public ActionResult Index()
		{
            return View();
		}
        [Authorize]
        public ActionResult EditProfile()
		{
            string editUser = User.Identity.Name;
            var entity = memberRepo.Lord(editUser);
            ResetProfileVM model = entity.ToVM();
            model.UserAccount = editUser;

            return View(model);
		}
        [HttpPost]
        public ActionResult EditProfile(ResetProfileVM model, HttpPostedFileBase file)
		{
            if(!ModelState.IsValid)return View(model);

            model.File = file;
            ResetDataCommand command = new ResetDataCommand(memberRepo);
            string path = Server.MapPath("~/Files/MemberImages/");

			try
			{
                command.ResetProfile(path, model);
                return RedirectToAction("Index", "Members");
            }
            catch (Exception ex)
			{
                ModelState.AddModelError (string.Empty, ex.Message);
                return View();
			}
		}
        [Authorize]
        public ActionResult EditPassword()
		{
            return View();
		}
        [HttpPost]
        public ActionResult EditPassword(ResetPasswordVM model)
		{
            if (!ModelState.IsValid) return View(model);

            ResetDataCommand command = new ResetDataCommand(memberRepo);
            ResetPasswordResponse response = command.ResetPassword(model, User.Identity.Name);

			if (response.IsSuccess)
			{
                return RedirectToAction("Logout", "Members");
			}

            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View(model);
		}

    }
}