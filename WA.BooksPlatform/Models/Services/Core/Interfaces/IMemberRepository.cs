using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.BooksPlatform.Entities;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Services.Core.Interfaces
{
	public interface IMemberRepository
	{
		void Create(MemberEntity entity);

		/// <summary>
		/// 會員帳號資料存在與否
		/// </summary>
		/// <param name="account">需要判斷的帳號</param>
		/// <returns></returns>
		bool IsExist(string account);

		/// <summary>
		/// 用ID查看會員是否存在
		/// </summary>
		/// <param name="memberId"></param>
		/// <returns></returns>
		bool IsExist(int memberId);

		/// <summary>
		/// 用會員帳號找一筆資料
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		MemberEntity Lord(string account);

		/// <summary>
		/// 用會員ID找一筆資料
		/// </summary>
		/// <param name="memberId"></param>
		/// <returns></returns>
		MemberEntity Lord(int memberId);

		/// <summary>
		/// 只要會員的ID
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		int LordMemberId(string account);

		/// <summary>
		/// 作者資訊是否存在
		/// </summary>
		/// <param name="author">作者名稱</param>
		/// <returns></returns>
		bool IsAuthorExist(string author);

		/// <summary>
		/// 啟用會員帳號，加入Roles:General一般會員
		/// </summary>
		/// <param name="memberId">需要啟用的會員ID</param>
		void ActiveRegister(int memberId);

		/// <summary>
		/// 成為作者
		/// </summary>
		/// <param name="memberId">會員ID</param>
		/// <param name="author">作者名稱</param>
		void BecomeAuthor(int memberId, string author);

		/// <summary>
		/// 除了密碼和啟用會員資格之外都可以用來更新資料
		/// </summary>
		/// <param name="entity"></param>
		void Update(MemberEntityNoPassword entity);

		/// <summary>
		/// 要更新密碼用這個
		/// </summary>
		/// <param name="entity"></param>
		void Update(MemberEntity entity);
	}
}
