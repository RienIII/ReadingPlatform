using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataValidator;

namespace WA.BooksPlatform.Models.Entities
{
	/// <summary>
	/// 書籍
	/// </summary>
	public class BookEntity
	{
		/// <summary>
		/// 建立用
		/// </summary>
		/// <param name="name">書名</param>
		/// <param name="author">作者</param>
		/// <param name="blurb">簡介</param>
		public BookEntity(string name, string author, string blurb)
		{
			new DataValid<string>(name, "書名").StringRequired().StringLengthLessThan(50);
			new DataValid<string>(author, "作者名稱").StringRequired().StringLengthLessThan(50);
			new DataValid<string>(blurb, "簡介").StringRequired().StringLengthGreaterOrEqualThan(3);

			this.Name = name;
			this.AuthorName = author;
			this.Blurb = blurb;
			this.Status = true;
		}

		/// <summary>
		/// 取出詳細書籍資料
		/// </summary>
		/// <param name="id"></param>
		/// <param name="imageName">書籍封面</param>
		/// <param name="name">書名</param>
		/// <param name="author">作者</param>
		/// <param name="blurb">簡介</param>
		/// <param name="items"></param>
		/// <param name="status"></param>
		public BookEntity(int id, string imageName, string name, string author, string blurb, List<BookChapterEntity> items, bool status)
			:this(name, author, blurb)
		{
			this.Id = id;
			this.ImageFileName = imageName;
			this.Items = items;
			this.Status = status;
		}
		public int Id { get; set; }

		private string _ImageName;
		/// <summary>
		/// 封面圖
		/// </summary>
		public string ImageFileName
		{
			get => _ImageName;
			set => _ImageName = string.IsNullOrEmpty(value) ? string.Empty : value;
		}

		/// <summary>
		/// 書名
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 作者
		/// </summary>
		public string AuthorName { get; set; }

		public AuthorEntity Author { get; set; }

		/// <summary>
		/// 簡介
		/// </summary>
		public string Blurb { get; set; }

		public int? CategoryId { get; set; }

		private CategoryEntity _Category;
		/// <summary>
		/// 書籍分類
		/// </summary>
		public CategoryEntity Category
		{
			get => _Category;
			set => _Category = value == null ? null : value;
		}

		public List<BookChapterEntity> Items;
		public List<BookChapterEntity> GetItems() => this.Items;

		/// <summary>
		/// 書籍狀態 1=上架；2=付費書籍；3=下架
		/// </summary>
		public bool Status { get; set; }

		/// <summary>
		/// 總字數
		/// </summary>
		public int TotalWord => Items == null ? 0 : Items.Sum(x => x.WordCount);

		/// <summary>
		/// 異動日期
		/// </summary>
		public DateTime ModifiedTime { get; set; }

		/// <summary>
		/// 點擊數
		/// </summary>
		public int Clicks { get; set;}

		/// <summary>
		/// 按讚數
		/// </summary>
		public int Likes { get; set; }

		/// <summary>
		/// 收藏數
		/// </summary>
		public int Collection { get; set; }

		public void RemovePart(int partId)
		{

		}
		public void RemoveChapter(int chapterId)
		{
			var item = Items.SingleOrDefault(x=>x.Id == chapterId);

			if (item == null) return;

			Items.Remove(item);
		}
		public void UpdateItem(int chapterId, string title, string content)
		{
			if(string.IsNullOrEmpty(content)) content = string.Empty;
			if(string.IsNullOrEmpty(title)) title = string.Empty;

			var item = Items.SingleOrDefault(x => x.Id == chapterId);

			if(item == null) return;

			item.Name = title;
			item.Artical = content;
		}
	}
}