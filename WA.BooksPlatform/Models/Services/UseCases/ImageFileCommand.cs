using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.Infrastructurse.Exts;
using WA.BooksPlatform.Models.Services.Core;
using WA.BooksPlatform.Models.ViewModels;

namespace WA.BooksPlatform.Models.Services.UseCases
{
	public class ImageFileCommand
	{
		public void ResetProfile(string path, ResetProfileVM model)
		{
			MemberService service = new MemberService();

			string newImageFileName = SaveFile(path, model.File);
			string originalFileName = service.LordFileName(model.UserAccount);
			string fileName = string.IsNullOrEmpty(newImageFileName) ? originalFileName : newImageFileName;
			model.ImageFileName = fileName;

			service.ResetProfile(model.ToRequest());

			if(!string.IsNullOrEmpty(originalFileName))DeleteFile(path, originalFileName);
		}

		/// <summary>
		/// 存檔
		/// </summary>
		/// <param name="path">路徑</param>
		/// <param name="file"></param>
		/// <returns></returns>
		private string SaveFile(string path, HttpPostedFileBase file)
		{
			// 如果沒有檔案 就是空值
			if (file == null || string.IsNullOrEmpty(file.FileName) || file.ContentLength == 0) return string.Empty;

			// 取得副檔名
			string ext = System.IO.Path.GetExtension(file.FileName);

			// 幫檔案取新名字，因為不想要檔名重複
			string targetFileName = Guid.NewGuid().ToString("N") + ext;

			// 組合成路徑
			string fullName = System.IO.Path.Combine(path, targetFileName);

			// 存檔案
			file.SaveAs(fullName);

			return targetFileName;
		}

		/// <summary>
		/// 刪除檔案
		/// </summary>
		/// <param name="path">檔案路徑</param>
		/// <param name="fileName">舊檔名稱</param>
		public void DeleteFile(string path, string fileName)
		{
			// 找出原始檔案的路徑
			string fullName = System.IO.Path.Combine(path, fileName);

			// 看這個路徑的檔案是否存在
			if (!System.IO.File.Exists(fullName)) return;

			// 刪除
			System.IO.File.Delete(fullName);
		}
	}
}