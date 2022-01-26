using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.Infrastructurse.Exts;
using WA.BooksPlatform.Models.Infrastructurse.Repositories;
using WA.BooksPlatform.Models.Services.Core.Interfaces;

namespace WA.BooksPlatform.Models.Services.Core
{
	public class AuthorService
	{
		IBookRepository bookRepo;
		IMemberRepository memberRepo;
		IAuthorRepository authorRepo = new AuthorRepository();
		public AuthorService(IBookRepository bookRepository, IMemberRepository memberRepository)
		{
			this.bookRepo = bookRepository;
			this.memberRepo = memberRepository;
		}
		public CreateBookResponse BookCreate(CreateBookRequest request, string userName)
		{
			if (bookRepo.IsExist(request.Name)) return CreateBookResponse.Fail("您所創建的書名已被使用!");

			var member = memberRepo.Lord(userName);
			if (member == null) return CreateBookResponse.Fail("作者不存在");
			if (!member.Roles.Contains("Author")) return CreateBookResponse.Fail("您還沒有成為作者喔");

			authorRepo.BookCreate(request.ToEntity(member.Author));

			return CreateBookResponse.Success();
		}

		public CreateBookResponse BookChapterCreate(BookChapterCreateRequest request, int bookId)
		{
			var book = bookRepo.Lord(bookId, true);

			if (book == null) return CreateBookResponse.Fail("書籍不存在");

			if (book.GetItems().SingleOrDefault(x => x.Name == request.Name) != null)
			{
				return CreateBookResponse.Fail("章節名稱已存在");
			}

			authorRepo.BookChapterCreate(bookId, request.ToEntity());

			return CreateBookResponse.Success();
		}
	}
}