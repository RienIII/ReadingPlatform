using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.EFModels;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class CategoryExts
	{
		public static CategoryEntity ToEntity(this Category category)
		{
			return new CategoryEntity
			{
				Id = category.Id,
				Name = category.Name,
				DisplayOrder = category.DisplayOrder
			};
		}
	}
}