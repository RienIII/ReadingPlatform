using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;
using WA.BooksPlatform.Models.Infrastructurse.Exts;
using WA.BooksPlatform.Models.Services.Core.Interfaces;

namespace WA.BooksPlatform.Models.Infrastructurse.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private AppDbContext db;
		public CategoryRepository(AppDbContext dataBase)
		{
			this.db = dataBase;
		}
		public List<CategoryEntity> Search(int? categoryId)
		{
			var query = db.Categories.AsNoTracking();

			if (categoryId.HasValue) query.Where(x => x.Id == categoryId.Value);

			var category = query.OrderBy(x=>x.Name).ToList().Select(x=>x.ToEntity());

			return category.ToList();
		}
	}
}