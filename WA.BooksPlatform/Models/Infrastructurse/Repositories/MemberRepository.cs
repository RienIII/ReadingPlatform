using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using WA.BooksPlatform.Entities;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse.Exts;
using WA.BooksPlatform.Models.Services.Core.Interfaces;

namespace WA.BooksPlatform.Models.Infrastructurse.Repositories
{
	public class MemberRepository : IMemberRepository
	{
		private readonly string connString = ConfigurationManager.ConnectionStrings["AppDbContext"].ToString();
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
			string sql = @"update Members set IsConfirmed=@IsConfirmed, ConfirmCode=NULL, Roles=@Roles where Id=@Id";
			var member = new Member { IsConfirmed = true, Roles = "General" , Id = memberId};
			using (var conn = new SqlConnection(connString))
			{
				conn.Execute(sql, member);
			}
		}

		public void Create(MemberEntity entity)
		{
			var member = entity.ToEF();

			db.Members.Add(member);
			db.SaveChanges();
		}

		public bool IsExist(string account)
			=>db.Members.AsNoTracking().SingleOrDefault(x => x.Account == account) != null;

		public bool IsExist(int memberId)
		{
			var member = db.Members.Find(memberId);

			return member == null ? false : true;
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
		public int LordMemberId(string account)
		{
			string sql = @"select Id from Members where Account=@Account";
			var data = new { Account = account };

			Member member = new Member();
			using(var conn = new SqlConnection(connString))
			{
				var result = conn.QuerySingleOrDefault(sql, data);
				member.Id = result.Id;
			}
			return member.Id;
		}

		public bool IsAuthorExist(string author)
			=>db.Authors.AsNoTracking().SingleOrDefault(x=>x.Name == author) != null;

		public void Update(MemberEntityNoPassword entity)
		{
			var member = db.Members.SingleOrDefault(x=>x.Account == entity.Account);

			member.Email = entity.Email;
			member.Name = entity.Name;
			member.ImageFileName = entity.ImageFileName;
			member.IsConfirmed = entity.IsConfirmed;
			member.ConfirmCode = entity.ConfirmCode;
			member.ResetPasswordCode = entity.ResetPasswordCode;
			member.Roles = entity.Roles;

			db.SaveChanges();
		}

		public void Update(MemberEntity entity)
		{
			var member = db.Members.SingleOrDefault(x => x.Account == entity.Account);

			member.Password = entity.EnctryptedPassword;

			db.SaveChanges();
		}

		public void BecomeAuthor(int memberId, string author)
		{
			string sql = @"insert into Authors(Name, MemberId)values(@Name, @MemberId);update Members set Roles=@Roles";
			var becomeAuthor = new { Name = author, MemberId = memberId , Roles = "General,Author" };

			using (var conn = new SqlConnection(connString))
			{
				conn.Execute(sql, becomeAuthor);
			}
		}
	}
}