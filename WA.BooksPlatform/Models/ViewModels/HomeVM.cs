using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WA.BooksPlatform.Models.DTOs;
using WA.BooksPlatform.Models.Entities;

namespace WA.BooksPlatform.Models.ViewModels
{
	public class HomeVM
	{
		public BookBasicEntity Books { get; set; }
		public string Search { get; set; }
	}
}