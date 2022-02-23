using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class MessageBoardEntityExts
	{
		public static MessageBoard ToEF(this MessageBoardEntity entity)
		{
			return new MessageBoard
			{
				BookId = entity.BookId,
				MemberId = entity.MemberId,
				Title = entity.Title,
				Chapter = entity.Chapter,
				CreateTime = DateTime.Now,
				Good = 0,
				Bad = 0
			};
		}
	}
}