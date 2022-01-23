using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse.Repositories;
using WA.BooksPlatform.Models.Services.Core;
using WA.BooksPlatform.Models.Services.Core.Interfaces;

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
			// 點開書籍畫面
			BookTest bookTest = new BookTest();
			bookTest.Lord();
			// 首頁熱門書籍
			bookTest.Current();
			// 首頁最近更新書籍
			bookTest.GetLatest();
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
	
}
