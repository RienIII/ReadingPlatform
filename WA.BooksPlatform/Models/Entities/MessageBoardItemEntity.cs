using DataValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA.BooksPlatform.Models.Entities
{
	public class MessageBoardItemEntity
	{
        /// <summary>
        /// 新增新的留言
        /// </summary>
        /// <param name="messageBoardId">目標評論區ID</param>
        /// <param name="memberId">留言的會員ID</param>
        /// <param name="chapter">留言內容</param>
		public MessageBoardItemEntity(int messageBoardId, int memberId, string chapter)
		{
            new DataValid<int>(messageBoardId, "留言目標").GreaterThan(0);
            new DataValid<int>(memberId, "會員ID").GreaterThan(0);
            new DataValid<string>(chapter, "內容").StringRequired().StringLengthLessThan(500);

            this.MessageBoardId = messageBoardId;
            this.MemberId = memberId;
            this.Chapter = chapter;
		}

        /// <summary>
        /// 從資料庫取得資料用
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="messageBoardId"></param>
        /// <param name="memberId"></param>
        /// <param name="chapter"></param>
        /// <param name="createTime"></param>
		public MessageBoardItemEntity(int Id, int messageBoardId, int memberId, string memberName, string chapter, DateTime createTime)
            :this(messageBoardId, memberId, chapter)
		{
            this.Id = Id;
            this.MemberName = memberName;
            this.CreateTime = createTime;
		}
        public int Id { get; set; }

        public int MessageBoardId { get; set; }

        public int MemberId { get; set; }
		public string MemberName { get; set; }

		public string Chapter { get; set; }

        public DateTime CreateTime { get; set; }
    }
}