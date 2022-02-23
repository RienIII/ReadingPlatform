using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class MessageBoardItemEntityExts
	{
		public static MessageBoardItem ToEF(this MessageBoardItemEntity entity)
		{
			return new MessageBoardItem
			{
				MessageBoardId = entity.MessageBoardId,
				MemberId = entity.MemberId,
				Chapter = entity.Chapter,
				CreateTime = DateTime.Now
			};
		}
	}
}