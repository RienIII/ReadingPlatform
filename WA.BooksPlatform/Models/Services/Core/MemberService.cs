using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HashUtilities;
using WA.BooksPlatform.Entities;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.Infrastructurse.Exts;
using WA.BooksPlatform.Models.Services.Core.Interfaces;

namespace WA.BooksPlatform.Models.Services.Core
{
	public class MemberService
	{
		private readonly IMemberRepository repository;

		public MemberService()
		{

		}
		public MemberService(IMemberRepository repo)
		{
			this.repository = repo;
		}

		/*------------------------------------------ 註冊 ------------------------------------------*/
		public RegisterResponse CreateNewMember(RegisterRequest request)
		{
			if (!repository.IsExist(request.Account))
			{
				return RegisterResponse.Fail("帳號已存在");
			}

			string confirmCode = Guid.NewGuid().ToString("N");

			repository.Create(request.ToEntity(confirmCode));
			MemberEntityNoPassword result = repository.Lord(request.Account);

			return RegisterResponse.Success(result);
		}

		/*------------------------------------------ 啟用會員資格 ------------------------------------------*/
		public void AtiveRegister(int memberId, string confirmCode)
		{
			MemberEntityNoPassword entity = repository.Lord(memberId);
			
			if (entity == null) return;

			if (entity.IsConfirmed) return;

			if (string.IsNullOrEmpty(entity.ConfirmCode)) return;

			if (string.Compare(entity.ConfirmCode, confirmCode) != 0) return;

			repository.ActiveRegister(memberId);
		}

		/*------------------------------------------ 登入 ------------------------------------------*/
		public LoginResponse Login(LoginRequest request)
		{
			MemberEntity entity = repository.Lord(request.Account);

			if (entity == null) return LoginResponse.Fail("帳號密碼有誤");
			if (!entity.IsConfirmed) return LoginResponse.Fail("帳號尚未進行驗證");

			return(string.Compare(entity.Password, request.EnctryptedPassword) != 0) 
				? LoginResponse.Fail("帳號密碼有誤") 
				: LoginResponse.Success();
		}

		/*------------------------------------------ 忘記密碼 ------------------------------------------*/
		/*按忘記密碼按鈕*/
		public RegisterResponse ForgetPassword(string account, string email)
		{
			MemberEntityNoPassword entity = repository.Lord(account);

			if (entity == null) return RegisterResponse.Fail("帳號有誤");
			if (string.Compare(entity.Email, email) != 0) return RegisterResponse.Fail("Email有誤");

			string confirmCode = Guid.NewGuid().ToString("N");
			entity.ConfirmCode = confirmCode;

			repository.Update(entity);

			return RegisterResponse.Success(entity);
		}
		/*按Email連結重設密碼*/
		public void ForgetPassword(ForgetPasswordRequest request)
		{
			MemberEntity entity = repository.Lord(request.Id);
			if (entity == null) throw new Exception("找不到對應的會員紀錄");
			if (string.Compare(entity.ConfirmCode, request.ConfirmCode) != 0) throw new Exception("找不到對應的會員紀錄");

			entity.Password = request.NewPassword;
			repository.Update(entity);
		}

		/*------------------------------------------ 修改密碼 ------------------------------------------*/
		public ResetPasswordResponse ResetPassword(ResetPasswordRequest request)
		{
			MemberEntity entity = repository.Lord(request.UserAccount);

			if(entity == null) return ResetPasswordResponse.Fail("帳號不存在");

			string enctryptedPassword = HashUtility.ToSHA256(request.OriginalPassword, MemberEntity.SALT);
			if (string.Compare(enctryptedPassword, entity.Password) != 0) return ResetPasswordResponse.Fail("密碼錯誤");
			entity.Password = request.NewPassword;

			repository.Update(entity);

			return ResetPasswordResponse.Success();
		}

		/*------------------------------------------ 修改個人資料 ------------------------------------------*/
		public void ResetProfile(ResetProfileRequest request)
		{
			MemberEntityNoPassword entity = repository.Lord(request.UserAccount);
			if (entity == null) throw new Exception("帳號不存在");

			repository.Update(request.ToEntity());
		}
		public string LordFileName(string account)
		{
			MemberEntityNoPassword entity = repository.Lord(account);
			if (entity == null) throw new Exception("帳號不存在");

			return entity.ImageFileName;
		}
	}
}