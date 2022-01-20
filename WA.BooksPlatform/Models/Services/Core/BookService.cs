﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse.Repositories;
using WA.BooksPlatform.Models.Services.Core.Interfaces;

namespace WA.BooksPlatform.Models.Services.Core
{
	/// <summary>
	/// 在首頁、搜尋頁、排行頁顯示查詢結果
	/// 也可以在這些頁面點開書籍觀看
	/// </summary>
	public class BookService
	{
		private readonly IBookRepository bookRepository;
		private readonly IBookNoSearchRepository bookNoSearchRepository;
		public BookService(IBookRepository bookRepo, IBookNoSearchRepository bookNoSearchRepo)
		{
			this.bookRepository = bookRepo;
			this.bookNoSearchRepository = bookNoSearchRepo;
		}
		/// <summary>
		/// 點進書籍時，會呈現該書籍
		/// </summary>
		/// <param name="bookId"></param>
		/// <returns></returns>
		public BookEntity AppearBook(int bookId)
		{
			if (!bookRepository.IsExist(bookId)) return null;

			return bookRepository.Lord(bookId, true);
		}

		/// <summary>
		/// 用在首頁當前熱門、排行或是搜尋時用到
		/// </summary>
		/// <param name="bookName"></param>
		/// <returns></returns>
		public List<BookBasicEntity> Current(string bookName)
		{
			return bookRepository.Search(null, bookName, true);
		}
		/// <summary>
		/// 最近更新
		/// </summary>
		/// <returns></returns>
		public List<BookBasicEntity> CurrentLatest()
		{
			return bookNoSearchRepository.GetAllBooks(true);
		}
	}
}