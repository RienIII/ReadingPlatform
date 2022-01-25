using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataValidator;

namespace WA.BooksPlatform.Models.Entities
{
	/// <summary>
	/// 書架
	/// </summary>
	public class BookshelfEntity
	{
		/// <summary>
		/// 新建書架
		/// </summary>
		/// <param name="name">書架名稱</param>
		/// <param name="memberId"></param>
		public BookshelfEntity(int memberId)
		{
			new DataValid<int>(memberId, "會員ID").GreaterThan(0);

			this.MemberId = memberId;
		}

		/// <summary>
		/// 讀取書架資訊
		/// </summary>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <param name="memberId"></param>
		/// <param name="bookItem"></param>
		public BookshelfEntity(int id, int memberId, List<BookshelfItemEntity> bookItem):this(memberId)
		{
			this.Id = id;
			this.Books = bookItem;
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public int MemberId { get; set; }

		/// <summary>
		/// 書架裡面的書籍
		/// </summary>
		public List<BookshelfItemEntity> Books { get; set; }

		/// <summary>
		/// 新增書籍
		/// </summary>
		/// <param name="bookItem">書籍</param>
		/// <exception cref="Exception">可能新增的書籍已經不存在</exception>
		public void AddItem(BookshelfItemEntity bookItem)
		{
			if (bookItem == null) throw new Exception("書籍不存在");

			if (Books.SingleOrDefault(x=>x.Book.Id == bookItem.Book.Id)!=null) return;

			var item = Books.SingleOrDefault(x=>x.Id == bookItem.Id);

			if(item == null) Books.Add(bookItem);

			else return;
		}

		/// <summary>
		/// 移除書籍
		/// </summary>
		/// <param name="bookId"></param>
		public void RemoveItem(int bookId)
		{
			var item = Books.SingleOrDefault(x=>x.Id == bookId);

			if (item == null) return;

			Books.Remove(item);
		}

		/// <summary>
		/// 取得書架的書籍
		/// </summary>
		public IEnumerable<BookshelfItemEntity> GetBook => this.Books;
	}
}