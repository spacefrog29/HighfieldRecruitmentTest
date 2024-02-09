using FrontEnd.Server.Models;
using HighFieldTest.Server.Models;

namespace FrontEnd.Server.Services
{
	public interface IUserEntityService
	{
		IEnumerable<UserEntity> GetAllUsers(HttpClient _httpClient);
		IEnumerable<TopColoursDTO> FavouriteColours(HttpClient _httpClient);
		List<UserEntity>? addDob(List<UserEntity>? userList);
		int CalculateAge(DateTime dob);
		List<TopColoursDTO> GetTopColours(List<UserEntity>? userList);
		
	}
}
