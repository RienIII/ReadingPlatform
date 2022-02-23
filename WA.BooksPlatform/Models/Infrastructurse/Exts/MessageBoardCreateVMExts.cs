using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class MessageBoardCreateVMExts
	{
		public static MessageBoardRequest ToRequest(this MessageBoardCreateVM model, int bookId, int memberId)
		{
			return new MessageBoardRequest
			{
				BookId = bookId,
				MemberId = memberId,
				Title = model.Title,
				Chapter = model.Chapter
			};
		}
	}
}