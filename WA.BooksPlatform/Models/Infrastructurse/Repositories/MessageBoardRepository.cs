using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse.Exts;
using WA.BooksPlatform.Models.Services.Core.Interfaces;

namespace WA.BooksPlatform.Models.Infrastructurse.Repositories
{
	public class MessageBoardRepository : IMessageBoardRepository
	{
		private readonly string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ToString();
		private AppDbContext db;
		public MessageBoardRepository(AppDbContext dataBase)
		{
			this.db = dataBase;
		}
		public void Create(MessageBoardEntity entity)
		{
			db.MessageBoards.Add(entity.ToEF());
			db.SaveChanges();
		}

		public void Create(MessageBoardItemEntity entity)
		{
			if (!IsExist(entity.MessageBoardId)) return;

			db.MessageBoardItems.Add(entity.ToEF());
			db.SaveChanges();
		}

		public bool IsExist(int messageBoardId)
			=>db.MessageBoards.Find(messageBoardId) == null ? false : true;

		public MessageBoardEntity Lord(int messageBoardId)
		{
			return db.MessageBoards
				.AsNoTracking()
				.Include(x=>x.MessageBoardItems)
				.SingleOrDefault(x=>x.Id == messageBoardId)
				.ToEntity();
		}

		public List<MessageBoardEntity> Search(int bookId, ForPages pages)
		{
			var messageBoards = db.MessageBoards
				.AsNoTracking()
				.Include(x=>x.MessageBoardItems)
				.Where(x=>x.BookId == bookId);

			double count = messageBoards.Count();
			pages = ForPagesExts.GetPages(count, pages);

			var result = messageBoards
				.OrderBy(x=>x.CreateTime)
				.Skip((pages.NowPage - 1) * pages.ItemNumPage)
				.Take(pages.ItemNumPage)
				.ToList().Select(x=>x.ToEntity());

			return result.ToList();
		}
	}
}