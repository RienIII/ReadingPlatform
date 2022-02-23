using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse;
using WA.BooksPlatform.Models.Infrastructurse.Exts;
using WA.BooksPlatform.Models.Infrastructurse.Repositories;
using WA.BooksPlatform.Models.Services.Core.Interfaces;

namespace WA.BooksPlatform.Models.Services.Core
{
	public class MessageBoardService
	{
		private IMessageBoardRepository messageBoardRepo;
		private IBookRepository bookRepo = new BookRepository();
		public MessageBoardService(IMessageBoardRepository messageBoardRepository)
		{
			this.messageBoardRepo = messageBoardRepository;
		}
		public CommonResponse CreateMessageBoard(MessageBoardRequest request)
		{
			if (!bookRepo.IsExist(request.BookId)) return CommonResponse.Fail("需要評論的書籍不存在");

			messageBoardRepo.Create(request.ToEntity());

			return CommonResponse.Success();
		}
		public CommonResponse CreateMessageBoardItem(MessageBoardItemRequest request)
		{
			if (!messageBoardRepo.IsExist(request.MessageBoardId)) return CommonResponse.Fail("您要留言的評論不存在");

			messageBoardRepo.Create(request.ToEntity());

			return CommonResponse.Success();
		}
	}
}