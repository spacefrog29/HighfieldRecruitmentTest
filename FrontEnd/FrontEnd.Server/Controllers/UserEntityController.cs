using FrontEnd.Server.Models;
using FrontEnd.Server.Services;
using HighFieldTest.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FrontEnd.Server.Controllers
{
	[ApiController]
	[Route("api/")]
	public class UserEntityController : ControllerBase
	{
		Uri baseAddress = new Uri("https://recruitment.highfieldqualifications.com/api/test");
		private readonly HttpClient _httpClient;
		private readonly IUserEntityService _userEntityService;
		public UserEntityController(IUserEntityService userEntityService)
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = baseAddress;
			_userEntityService = userEntityService;
		}

		[HttpGet]
		[Route("getAllUsers")]
		public IEnumerable<UserEntity> UserEntity()
		{
			return _userEntityService.GetAllUsers(_httpClient);
		}

		[HttpGet]
		[Route("getColourList")]
		public IEnumerable<TopColoursDTO> FavouriteColours()
		{
			return _userEntityService.FavouriteColours(_httpClient);
		}


	}
}