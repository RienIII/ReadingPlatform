﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse.Exts;
using WA.BooksPlatform.Models.Services.Core.Interfaces;

namespace WA.BooksPlatform.Models.Services.Core
{
	/// <summary>
	/// 書架的Service
	/// </summary>
	public class BookshelfService
	{
		private readonly IBookshelfRepository bookshelfRepository;
		private readonly IBookRepository bookRepository;
		public BookshelfService(IBookshelfRepository bookshelfRepo, IBookRepository bookRepo)
		{
			this.bookshelfRepository = bookshelfRepo;
			this.bookRepository = bookRepo;
		}

		/// <summary>
		/// 可能是新建帳號，會沒有書架的存在，在這邊進行判斷
		/// </summary>
		/// <param name="memberId"></param>
		/// <returns></returns>
		public BookshelfEntity Current(int memberId)
		{
			if (!bookshelfRepository.IsExist(memberId))
			{
				return bookshelfRepository.CreateNewBookshelf(memberId);
			}
			return bookshelfRepository.Lord(memberId);
		}

		/// <summary>
		/// 新增書籍到書架
		/// </summary>
		/// <param name="memberId"></param>
		/// <param name="bookId">需要新增到書架的書籍ID</param>
		public void AddItem(int memberId, int bookId)
		{
			var bookshelf = Current(memberId);

			var book = bookRepository.Lord(bookId, true).ToBookBasic();

			bookshelf.AddItem(book);

			bookshelfRepository.Save(bookshelf);
		}

		/// <summary>
		/// 移除書架的某本書籍
		/// </summary>
		/// <param name="memberId"></param>
		/// <param name="bookId">需要移除的書籍ID</param>
		public void RemoveItem(int memberId, int bookId)
		{
			var bookshelf = Current(memberId);

			bookshelf.RemoveItem(bookId);

			bookshelfRepository.Save(bookshelf);
		}
	}
}