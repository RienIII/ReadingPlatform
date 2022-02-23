using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class MessageBoardItemCreateVMExts
	{
		public static MessageBoardItemRequest ToRequest(this MessageBoardItemCreateVM model, int messageBoardId, int memberId)
		{
			return new MessageBoardItemRequest
			{
				MessageBoardId = messageBoardId,
				MemberId = memberId,
				Chapter = model.Chapter
			};
		}
	}
}