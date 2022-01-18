using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Services.Core.Interfaces
{
	public interface IBookshelfRepository
	{
		/// <summary>
		/// 確認是否存在書架，像是新加入會員是沒有新增書架的
		/// </summary>
		/// <param name="memberId"></param>
		/// <returns></returns>
		bool IsExist(int memberId);

		/// <summary>
		/// 如果沒有就建立一個
		/// </summary>
		/// <param name="memberId"></param>
		/// <returns></returns>
		BookshelfEntity CreateNewBookshelf(int memberId);

		/// <summary>
		/// 載入書架
		/// </summary>
		/// <param name="memberId"></param>
		/// <returns></returns>
		BookshelfEntity Lord(int memberId);

		/// <summary>
		/// 更新完成後進行儲存
		/// </summary>
		/// <param name="bookshelf"></param>
		void Save(BookshelfEntity bookshelf);
	}
}
