using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Services.Core.Interfaces
{
	public interface IAuthorRepository
	{
		void BookCreate(BookEntity entity);
		void BookChapterCreate(int bookId, BookChapterEntity entity);
	}
}
