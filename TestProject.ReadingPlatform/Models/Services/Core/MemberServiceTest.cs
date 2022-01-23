using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashUtilities;
using NSubstitute;
using NUnit.Framework;
using WA.BooksPlatform.Entities;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.Services.Core;
using WA.BooksPlatform.Models.Services.Core.Interfaces;

namespace TestProject.ReadingPlatform.Models.Services.Core
{
	public class MemberServiceTest
	{
		private IMemberRepository repo;
		bool isSuccess;
		private MemberService service;
		[SetUp]
		public void SetUpTest()
		{
			this.repo = Substitute.For<IMemberRepository>();
			isSuccess = true;
			this.service = new MemberService(repo);
		}
		[Test]
		public void CreateNewMember_帳號已存在_ReturnFalse()
		{
			RegisterRequest request = new RegisterRequest { Account = "Rien", Email = "aaa", Name = "rien", Password = "123" };
			repo.IsExist(request.Account).Returns(true);

			var result = service.CreateNewMember(request);
			Assert.IsFalse(result.IsSuccess);
		}
		[Test]
		public void AtiveRegister_帳號不存在_ReturnFalse()
		{
			MemberEntityNoPassword entity = null;
			repo.Lord(1).Returns(entity);

			service.AtiveRegister(1, "123", out isSuccess);

			Assert.AreEqual(false, isSuccess);
		}
		[Test]
		public void AtiveRegister_帳號已啟用_ReturnFalse()
		{
			MemberEntity entity = new MemberEntity("Huang", "huang", "xx@xx", "123", "456") { Id = 1, IsConfirmed = true};
			repo.Lord(1).Returns(entity);

			service.AtiveRegister(1, "123", out isSuccess);

			Assert.IsFalse(isSuccess);
		}
		[Test]
		public void AtiveRegister_啟用碼是空的代表已啟用_ReturnFalse()
		{
			MemberEntity entity = new MemberEntity("Huang", "huang", "xx@xx", "123", null) { Id = 1, IsConfirmed = false };
			repo.Lord(1).Returns(entity);

			service.AtiveRegister(1, "123", out isSuccess);

			Assert.IsFalse(isSuccess);
		}
		[Test]
		public void AtiveRegister_有啟用碼所以進行比對是否相同_ReturnFalse()
		{
			MemberEntity entity = new MemberEntity("Huang", "huang", "xx@xx", "123", "456") { Id = 1, IsConfirmed = false };
			repo.Lord(1).Returns(entity);

			service.AtiveRegister(1, "123", out isSuccess);

			Assert.IsFalse(isSuccess);
		}
		[Test]
		public void Login_沒有這個會員_ReturnFalse()
		{
			MemberEntity entity = null;
			repo.Lord("Huang").Returns(entity);

			LoginRequest request = new LoginRequest() { Account = "Huang", Password = "123" };
			var result = service.Login(request);

			Assert.IsFalse(result.IsSuccess);
		}
		[Test]
		public void Login_沒有啟用會員資格_ReturnFalse()
		{
			MemberEntity entity = new MemberEntity("Huang", "huang", "xx@xx", "123", "456") { Id = 1, IsConfirmed = false };
			repo.Lord("Huang").Returns(entity);

			LoginRequest request = new LoginRequest() { Account = "Huang", Password = "123" };
			var result = service.Login(request);

			Assert.IsFalse(result.IsSuccess);
		}
		[Test]
		public void Login_密碼錯誤_ReturnFalse()
		{
			MemberEntity entity = new MemberEntity("Huang", "huang", "xx@xx", "123", "abc") { Id = 1, IsConfirmed = true };
			repo.Lord("Huang").Returns(entity);

			LoginRequest request = new LoginRequest() { Account = "Huang", Password = "456" };
			var result = service.Login(request);

			Assert.IsFalse(result.IsSuccess);
		}
		[Test]
		public void Login_帳密正確_ReturnTrue()
		{
			MemberEntity entity = new MemberEntity("Huang", "huang", "xx@xx", "123", "abc") { Id = 1, IsConfirmed = true };
			repo.Lord("Huang").Returns(entity);
			entity.Password = entity.EnctryptedPassword;

			LoginRequest request = new LoginRequest() { Account = "Huang", Password = "123" };
			var result = service.Login(request);

			Assert.IsTrue(result.IsSuccess);
		}
		[Test]
		public void ForgetPassword_帳號有誤_ReturnFalse()
		{
			MemberEntity entity = null;
			repo.Lord("Huang").Returns(entity);

			var response = service.ForgetPassword("Huang", "xx@xx");

			Assert.IsFalse(response.IsSuccess);
		}
		[Test]
		public void ForgetPassword_Email有誤_ReturnFalse()
		{
			MemberEntity entity = new MemberEntity("Huang", "huang", "yy@xx", "123", null) { Id = 1, IsConfirmed = true };
			repo.Lord("Huang").Returns(entity);

			var response = service.ForgetPassword("Huang", "xx@xx");

			Assert.IsFalse(response.IsSuccess);
		}
		[Test]
		public void ForgetPassword_Email和帳號輸入正確_ReturnTrue()
		{
			MemberEntity entity = new MemberEntity("Huang", "huang", "xx@xx", "123", null) { Id = 1, IsConfirmed = true };
			repo.Lord("Huang").Returns(entity);

			var response = service.ForgetPassword("Huang", "xx@xx");

			Assert.IsTrue(response.IsSuccess);
		}
		[Test]
		public void ForgetPasswordEmail_會員不存在_ReturnFalse()
		{
			MemberEntity entity = null;
			repo.Lord("Huang").Returns(entity);

			ForgetPasswordRequest request = new ForgetPasswordRequest { Account = "Huang", NewPassword = "456", ConfirmCode = "abc" };
			RegisterResponse response = service.ForgetPassword(request);

			Assert.IsFalse(response.IsSuccess);
		}
		[Test]
		public void ForgetPasswordEmail_確認碼錯誤_ReturnFalse()
		{
			MemberEntity entity = new MemberEntity("Huang", "huang", "xx@xx", "123", null) { Id = 1, IsConfirmed = true, ResetPasswordCode = null };
			repo.Lord("Huang").Returns(entity);

			ForgetPasswordRequest request = new ForgetPasswordRequest { Account = "Huang", NewPassword = "456", ConfirmCode = "abc" };
			RegisterResponse response = service.ForgetPassword(request);

			Assert.IsFalse(response.IsSuccess);
		}
		[Test]
		public void ForgetPasswordEmail_成功修改密碼_ReturnTrue()
		{
			MemberEntity entity = new MemberEntity("Huang", "huang", "xx@xx", "123", null) { Id = 1, IsConfirmed = true, ResetPasswordCode = "abc" };
			repo.Lord("Huang").Returns(entity);

			ForgetPasswordRequest request = new ForgetPasswordRequest { Account = "Huang", NewPassword = "456", ConfirmCode = "abc" };
			RegisterResponse response = service.ForgetPassword(request);

			Assert.AreEqual(true, response.IsSuccess);
		}
		[Test]
		public void ResetPassword_帳號不存在_ReturnFalse()
		{
			MemberEntity entity = null;
			repo.Lord("Huang").Returns(entity);

			ResetPasswordRequest request = new ResetPasswordRequest { UserAccount = "Huang", OriginalPassword = "123", NewPassword = "456" };
			var result = service.ResetPassword(request);

			Assert.IsFalse(result.IsSuccess);
		}
		[Test]
		public void ResetPassword_原始密碼錯誤_ReturnFalse()
		{
			MemberEntity entity = new MemberEntity("Huang", "huang", "xx@xx", "123", null) { Id = 1, IsConfirmed = true };
			entity.Password = entity.EnctryptedPassword;
			repo.Lord("Huang").Returns(entity);

			ResetPasswordRequest request = new ResetPasswordRequest { UserAccount = "Huang", OriginalPassword = "456", NewPassword = "123" };

			var result = service.ResetPassword(request);

			Assert.IsFalse(result.IsSuccess);
		}
		[Test]
		public void ResetPassword_原始密碼正確_ReturnTrue()
		{
			MemberEntity entity = new MemberEntity("Huang", "huang", "xx@xx", "123", null) { Id = 1, IsConfirmed = true };
			entity.Password = entity.EnctryptedPassword;
			repo.Lord("Huang").Returns(entity);

			ResetPasswordRequest request = new ResetPasswordRequest { UserAccount = "Huang", OriginalPassword = "123", NewPassword = "123" };

			var result = service.ResetPassword(request);

			Assert.IsTrue(result.IsSuccess);
		}
	}
}
