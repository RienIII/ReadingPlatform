﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Entities;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Infrastructurse.Exts;
using WA.BooksPlatform.Models.Services.Core.Interfaces;

namespace WA.BooksPlatform.Models.Infrastructurse.Repositories
{
	public class MemberRepository : IMemberRepository
	{
		private AppDbContext db;
		public MemberRepository()
		{
			db = new AppDbContext();
		}
		public MemberRepository(AppDbContext dataBase)
		{
			this.db = dataBase;
		}
		public void ActiveRegister(int memberId)
		{
			var member = db.Members.Find(memberId);

			member.IsConfirmed = true;
			member.ConfirmCode = null;
			member.Roles = "General";

			db.SaveChanges();
		}

		public void Create(MemberEntity entity)
		{
			var member = entity.ToEF();

			db.Members.Add(member);
			db.SaveChanges();
		}

		public bool IsExist(string account)
		{
			var member = db.Members
				.AsNoTracking()
				.SingleOrDefault(x=>x.Account == account);

			return member != null ? false : true;
		}

		public bool IsExist(int memberId)
		{
			var member = db.Members.Find(memberId);

			return member != null ? false : true;
		}

		public MemberEntity Lord(string account)
		{
			if (!IsExist(account)) return null;

			return db.Members
				.AsNoTracking()
				.SingleOrDefault(x=>x.Account == account)
				.ToEntity();
		}

		public MemberEntity Lord(int memberId)
		{
			if(!IsExist(memberId))return null;

			return db.Members
				.Find(memberId)
				.ToEntity();
		}

		public void Update(MemberEntityNoPassword entity)
		{
			var member = db.Members.SingleOrDefault(x=>x.Account == entity.Account);

			member.Account = entity.Account;
			member.Email = entity.Email;
			member.Name = entity.Name;
			member.ImageFileName = entity.ImageFileName;
			member.IsConfirmed = entity.IsConfirmed;
			member.ConfirmCode = entity.ConfirmCode;
			member.ResetPasswordCode = entity.ResetPasswordCode;
			member.CreateTime = entity.CreateTime;

			db.SaveChanges();
		}

		public void Update(MemberEntity entity)
		{
			var member = db.Members.SingleOrDefault(x => x.Account == entity.Account);

			member.Password = entity.EnctryptedPassword;

			db.SaveChanges();
		}
	}
}