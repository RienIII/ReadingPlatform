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
		public BookshelfEntity(string name, int memberId)
		{
			new DataValid<string>(name, "書架名稱").StringRequired().StringLengthGreaterThan(0);
			new DataValid<int>(memberId, "會員ID").GreaterThan(0);

			this.Name = name;
			this.MemberId = memberId;
		}

		/// <summary>
		/// 讀取書架資訊
		/// </summary>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <param name="memberId"></param>
		/// <param name="book"></param>
		public BookshelfEntity(int id, string name, int memberId, List<BookBasicEntity> book):this(name, memberId)
		{
			this.Id = id;
			this.Books = book;
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public int MemberId { get; set; }

		/// <summary>
		/// 書架裡面的書籍
		/// </summary>
		public List<BookBasicEntity> Books { get; set; }

		/// <summary>
		/// 新增書籍
		/// </summary>
		/// <param name="bookBasic">書籍</param>
		/// <exception cref="Exception">可能新增的書籍已經不存在</exception>
		public void AddItem(BookBasicEntity bookBasic)
		{
			if (bookBasic == null) throw new Exception("書籍不存在");

			var item = Books.SingleOrDefault(x=>x.Id == bookBasic.Id);

			if(item == null) Books.Add(bookBasic);
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
		public IEnumerable<BookBasicEntity> GetItem => this.Books;
	}
}