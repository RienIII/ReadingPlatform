using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Models.Infrastructurse.Exts
{
	public static partial class ManageAuthorBookCreateVMExts
	{
		public static CreateBookRequest ToRequest(this ManageAuthorBookCreateVM model)
		{
			return new CreateBookRequest
			{
				Name = model.Name,
				Blurb = model.Blurb,
				ImageFilaName = model.ImageFilaName,
				CategoryId = model.CategoryId
			};
		}
	}
}