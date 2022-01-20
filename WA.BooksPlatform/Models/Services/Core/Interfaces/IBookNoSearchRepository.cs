using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Services.Core.Interfaces
{
	public interface IBookNoSearchRepository
	{
		/// <summary>
		/// 查看書籍存在與否
		/// </summary>
		/// <param name="bookId"></param>
		/// <returns></returns>
		bool IsExist(int bookId);
		/// <summary>
		/// 載入一筆書籍
		/// </summary>
		/// <param name="bookId"></param>
		/// <param name="status">書籍預設為True，上架狀態</param>
		/// <returns></returns>
		BookEntity Lord(int bookId, bool? status);
		/// <summary>
		/// 顯示需要載入的書籍基本資料，但是沒有搜尋條件
		/// </summary>
		/// <param name="status">只找的到上架的書籍</param>
		/// <returns></returns>
		List<BookBasicEntity> GetAllBooks(bool? status);
	}
}
