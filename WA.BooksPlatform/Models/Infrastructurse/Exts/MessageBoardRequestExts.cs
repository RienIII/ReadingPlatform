using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class MessageBoardRequestExts
	{
		public static MessageBoardEntity ToEntity(this MessageBoardRequest request)
			=>new MessageBoardEntity(request.BookId, request.MemberId, request.Title, request.Chapter);
		
	}
}