using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse;

namespace WA.BooksPlatform.Models.ViewModels
{
	public class MessageBoardIndexVM
	{
		public List<MessageBoardEntity> MessageBoard { get; set; }
		public ForPages ForPages { get; set; }
	}
}