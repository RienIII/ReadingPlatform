using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse.Repositories;
using WA.BooksPlatform.Models.Services.Core;
using WA.BooksPlatform.Models.Services.Core.Interfaces;
using ConsoleApp.ReadingPlatform.Models.EFModels;

namespace ConsoleApp.ReadingPlatform
{
	
	internal class Program
	{
		/// <summary>
		/// 用中斷點看查出來的東西是不是符合
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			//// 點開書籍畫面
			//BookTest bookTest = new BookTest();
			//bookTest.Lord();
			//// 首頁熱門書籍
			//bookTest.Current();
			//// 首頁最近更新書籍
			//bookTest.GetLatest();

			DisplayBook book = new DisplayBook();
			book.Lord(1);
		}
	}
	public class Member
	{
		private IMemberRepository memberRepo = new MemberRepository();
		public void CreateNewMember()
		{
			MemberService service = new MemberService(memberRepo);
			RegisterRequest request = new RegisterRequest
			{
				Account = "Huang",
				Password = "123",
				Name = "huang",
				Email = "n1086403@ntub.edu.tw"
			};

			RegisterResponse response = service.CreateNewMember(request);
		}
	}
	public class DisplayBook
	{
		private readonly string connStr = @"Server=.\sql2019;Database=ReadingPlatform;User Id=sa5;Password=123;";
		public void Lord(int bookId)
		{
			string sql = @"select * from Books where Id=@Id";
			var bookData = new {Id = bookId};

			string sql2 = @"select * from BookChapters where BookId=@BookId";
			var chapterData = new { BookId = bookId };

			using (var conn = new SqlConnection(connStr))
			{
				Book books = conn.Query<Book>(sql, bookData).SingleOrDefault(x=>x.Id == bookId);
				books.BookChapters = conn.Query<BookChapter>(sql2, chapterData).ToList();
			}
			
		}
	}
}
