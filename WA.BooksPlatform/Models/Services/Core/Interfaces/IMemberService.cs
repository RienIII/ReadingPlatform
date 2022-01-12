using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.BooksPlatform.Models.DTOs;

namespace WA.BooksPlatform.Models.Services.Core.Interfaces
{
	public interface IMemberService
	{
		RegisterResponse CreateNewMember(RegisterRequest request);
	}
}
