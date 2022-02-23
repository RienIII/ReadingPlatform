using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class MessageBoardExts
	{
		public static MessageBoardEntity ToEntity(this MessageBoard messageBoard)
		{
			List<MessageBoardItemEntity> items = messageBoard.MessageBoardItems.Select(x => x.ToEntity()).ToList();
			return new MessageBoardEntity
			(
				messageBoard.Id,
				messageBoard.BookId,
				messageBoard.MemberId,
				messageBoard.Member.Name,
				messageBoard.Title,
				messageBoard.Chapter,
				items,
				messageBoard.CreateTime,
				messageBoard.Good,
				messageBoard.Bad
			);
		}
	}
}