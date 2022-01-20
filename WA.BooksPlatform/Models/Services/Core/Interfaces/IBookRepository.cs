using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Services.Core.Interfaces
{
	public interface IBookRepository
	{
		/// <summary>
		/// 查看所搜尋的書存在與否
		/// </summary>
		/// <param name="bookId">需要搜尋的書籍ID</param>
		/// <returns></returns>
		bool IsExist(int bookId);

		/// <summary>
		/// 載入一筆資料，但是已經進入書籍頁
		/// </summary>
		/// <param name="bookId"></param>
		/// <param name="status">書籍狀態；1=上架；2=下架</param>
		/// <returns></returns>
		BookEntity Lord(int bookId, bool? status);

		/// <summary>
		/// 載入多筆資料，是在首頁、排行或是搜尋頁所看到的書籍基本資料
		/// </summary>
		/// <param name="categoryId">根據分類尋找</param>
		/// <param name="bookName">根據書名尋找</param>
		/// <param name="status">書籍狀態；1=上架；2=下架</param>
		/// <returns></returns>
		List<BookBasicEntity> Search(int? categoryId, string bookName, bool? status);
	}
}
