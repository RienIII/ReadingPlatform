using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse;

namespace WA.BooksPlatform.Models.Services.Core.Interfaces
{
	public interface IMessageBoardRepository
	{
		/// <summary>
		/// 新增書籍的評論
		/// </summary>
		/// <param name="entity"></param>
		void Create(MessageBoardEntity entity);

		/// <summary>
		/// 新增評論底下的留言(回覆)
		/// </summary>
		/// <param name="entity"></param>
		void Create(MessageBoardItemEntity entity);

		/// <summary>
		/// 要留言的評論是否存在
		/// </summary>
		/// <param name="messageBoardId"></param>
		/// <returns></returns>
		bool IsExist(int messageBoardId);

		/// <summary>
		/// 取得書籍的評論內容，包含他的子項目(評論底下的留言)
		/// </summary>
		/// <param name="bookId">書籍ID</param>
		/// <param name="pages">分頁</param>
		/// <returns></returns>
		List<MessageBoardEntity> Search(int bookId, ForPages pages);

		/// <summary>
		/// 找一筆評論
		/// </summary>
		/// <param name="messageBoardId"></param>
		/// <returns></returns>
		MessageBoardEntity Lord(int messageBoardId);
	}
}
