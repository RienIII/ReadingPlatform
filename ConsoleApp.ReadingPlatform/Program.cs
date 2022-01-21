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
		static void Main(string[] args)
		{
			Books books = new Books();
			books.Lord();
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
	public class Books
	{
		private IBookRepository bookSearchRepo = new BookSearchRepository();
		private IBookRepository bookRankRepo = new BookRankRepository();
		private IBookNoSearchRepository bookHomeRepo = new BookHomeRepository();
		public void Lord()
		{
			BookService service = new BookService(bookSearchRepo, bookHomeRepo);

			BookEntity book = service.AppearBook(1);
		}
	}
}
