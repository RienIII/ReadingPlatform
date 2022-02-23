using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class MessageBoardItemRequestExts
	{
		public static MessageBoardItemEntity ToEntity(this MessageBoardItemRequest request)
			=>new MessageBoardItemEntity(request.MessageBoardId, request.MemberId, request.Chapter);
		
	}
}