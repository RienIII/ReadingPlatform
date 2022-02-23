using DataValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.Entities
{
	public class MessageBoardEntity
	{
        /// <summary>
        /// 建立新的書籍評論用
        /// </summary>
        /// <param name="bookId">目標書籍ID</param>
        /// <param name="memberId">評論會員ID</param>
        /// <param name="title">標題(50字)</param>
        /// <param name="chapter">內容(1000字)</param>
		public MessageBoardEntity(int bookId, int memberId, string title, string chapter)
		{
            new DataValid<int>(bookId, "書籍ID").GreaterThan(0);
            new DataValid<int>(memberId, "會員ID").GreaterThan(0);
            new DataValid<string>(title, "標題").StringRequired().StringLengthGreaterThan(2).StringLengthLessThan(50);
            new DataValid<string>(chapter, "內容").StringRequired().StringLengthGreaterThan(2).StringLengthLessThan(1000);

            this.BookId = bookId;
            this.MemberId = memberId;
            this.Title = title;
            this.Chapter = chapter;
        }

        /// <summary>
        /// 從資料庫取得資料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bookId"></param>
        /// <param name="memberId"></param>
        /// <param name="title">標題</param>
        /// <param name="chapter">內容</param>
        /// <param name="items">這個評論下的留言</param>
        /// <param name="createTime">評論時間</param>
        /// <param name="good">按讚數</param>
        /// <param name="bad">按不喜歡數</param>
		public MessageBoardEntity(int id, int bookId, int memberId, string memberName, string title, string chapter, List<MessageBoardItemEntity> items, DateTime createTime, int? good, int? bad)
            :this(bookId, memberId, title, chapter)
		{
            this.Id = id;
            this.Items = items;
            this.CreateTime = createTime;
            this.MemberName = memberName;
            if(good.HasValue)this.Good = good.Value;
            if(bad.HasValue)this.Bad = bad.Value;
		}

        public int Id { get; set; }

        public int BookId { get; set; }
		public string BookName { get; set; }

		public int MemberId { get; set; }
		public string MemberName { get; set; }

		public string Title { get; set; }

        public string Chapter { get; set; }

        private List<MessageBoardItemEntity> Items { get; set; }
        public List<MessageBoardItemEntity> GetItem() => this.Items;

        public DateTime CreateTime { get; set; }

        private int? _Good;
        public int? Good
		{
            get => _Good;
			set => _Good = value < 0 ? 0 : value;
		}

        private int? _Bad;
        public int? Bad
		{
            get => _Bad;
            set => _Bad = value < 0 ? 0 : value;
        }
    }
}