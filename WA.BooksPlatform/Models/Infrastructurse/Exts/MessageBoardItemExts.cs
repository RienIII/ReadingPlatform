using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class MessageBoardItemExts
	{
		public static MessageBoardItemEntity ToEntity(this MessageBoardItem item)
		{
			return new MessageBoardItemEntity
			(
				item.Id, 
				item.MessageBoardId, 
				item.MemberId, 
				item.Member.Name,
				item.Chapter, 
				item.CreateTime
			);
		}
	}
}