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
	/// <summary>
	/// 會員功能，註冊、登入與修改基本資訊
	/// </summary>
	public class MemberService
	{
		private readonly IMemberRepository repository;
		public MemberService(IMemberRepository repo)
		{
			this.repository = repo;
		}

		/// <summary>
		/// 註冊
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public RegisterResponse CreateNewMember(RegisterRequest request)
		{
			if (repository.IsExist(request.Account))
			{
				return RegisterResponse.Fail("帳號已存在");
			}

			string confirmCode = Guid.NewGuid().ToString("N");

			repository.Create(request.ToEntity(confirmCode));

			MemberEntityNoPassword result = repository.Lord(request.Account);

			return RegisterResponse.Success(result);
		}

		/// <summary>
		/// 啟用會員資格
		/// </summary>
		/// <param name="memberId"></param>
		/// <param name="confirmCode"></param>
		public void AtiveRegister(int memberId, string confirmCode, out bool isSuccess)
		{
			MemberEntityNoPassword entity = repository.Lord(memberId);
			
			if (entity == null)
			{
				isSuccess = false;
				return;
			}

			if (entity.IsConfirmed)
			{
				isSuccess = false;
				return;
			}

			if (string.IsNullOrEmpty(entity.ConfirmCode))
			{
				isSuccess = false;
				return;
			}

			if (string.Compare(entity.ConfirmCode, confirmCode) != 0)
			{
				isSuccess = false;
				return;
			}
			isSuccess = true;
			repository.ActiveRegister(memberId);
		}

		/// <summary>
		/// 登入
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public LoginResponse Login(LoginRequest request)
		{
			MemberEntity entity = repository.Lord(request.Account);

			if (entity == null) return LoginResponse.Fail("帳號密碼有誤");
			if (!entity.IsConfirmed) return LoginResponse.Fail("帳號尚未進行驗證");

			return(string.Compare(entity.Password, request.EnctryptedPassword) != 0) 
				? LoginResponse.Fail("帳號密碼有誤") 
				: LoginResponse.Success(entity.Roles);
		}

		/// <summary>
		/// 忘記密碼
		/// </summary>
		/// <param name="account"></param>
		/// <param name="email"></param>
		/// <returns></returns>
		public RegisterResponse ForgetPassword(string account, string email)
		{
			MemberEntityNoPassword entity = repository.Lord(account);

			if (entity == null) return RegisterResponse.Fail("帳號有誤");
			if (string.Compare(entity.Email, email) != 0) return RegisterResponse.Fail("Email有誤");

			string confirmCode = Guid.NewGuid().ToString("N");
			entity.ResetPasswordCode = confirmCode;

			repository.Update(entity);

			return RegisterResponse.Success(entity);
		}
		/// <summary>
		/// 按Email連結重設密碼
		/// </summary>
		/// <param name="request"></param>
		/// <exception cref="Exception"></exception>
		public RegisterResponse ForgetPassword(ForgetPasswordRequest request)
		{
			MemberEntity entity = repository.Lord(request.Id);
			if (entity == null)
			{
				return RegisterResponse.Fail("找不到對應的會員紀錄");
			}
			if (string.Compare(entity.ResetPasswordCode, request.ConfirmCode) != 0)
			{
				return RegisterResponse.Fail("找不到對應的會員紀錄");
			}

			entity.Password = request.NewPassword;
			repository.Update(entity);

			return RegisterResponse.Success(entity);
		}

		/// <summary>
		/// 修改密碼
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
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

		/// <summary>
		/// 修改個人資料
		/// </summary>
		/// <param name="request"></param>
		/// <exception cref="Exception"></exception>
		public void ResetProfile(ResetProfileRequest request)
		{
			MemberEntityNoPassword entity = repository.Lord(request.UserAccount);
			if (entity == null) throw new Exception("帳號不存在");

			entity.Name = request.Name;
			entity.Email = request.Email;
			entity.ImageFileName = request.ImageFileName;

			repository.Update(entity);
		}

		/// <summary>
		/// 尋找原始大頭貼檔名
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public string LordFileName(string account)
		{
			MemberEntityNoPassword entity = repository.Lord(account);
			if (entity == null) throw new Exception("帳號不存在");
			
			return entity.ImageFileName;
		}
	}
}