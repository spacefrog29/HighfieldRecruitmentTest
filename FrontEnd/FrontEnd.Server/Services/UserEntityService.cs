using FrontEnd.Server.Models;
using HighFieldTest.Server.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace FrontEnd.Server.Services
{
	public class UserEntityService : IUserEntityService
	{
		public UserEntityService()
		{

		}

		public IEnumerable<UserEntity> GetAllUsers(HttpClient _httpClient)
		{
			List<UserEntity> userList = new List<UserEntity>();
			HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress).Result;

			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				userList = JsonConvert.DeserializeObject<List<UserEntity>>(data);
				userList = addDob(userList);
			}
			return userList.ToArray();
		}

		public IEnumerable<TopColoursDTO> FavouriteColours(HttpClient _httpClient)
		{
			List<UserEntity> userList = new List<UserEntity>();
			List<TopColoursDTO> topColours = new List<TopColoursDTO>();
			HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress).Result;

			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				userList = JsonConvert.DeserializeObject<List<UserEntity>>(data);
				topColours = GetTopColours(userList);
			}
			return topColours.ToArray();
		}

		public List<UserEntity>? addDob(List<UserEntity>? userList)
		{
			if (userList.Any())
			{
				foreach (UserEntity user in userList)
				{
					DateTime dob = DateTime.Parse(user.dob.ToString());
					user.age = CalculateAge(dob);
					user.ageplus20 = user.age + 20;
				}
			}
			return userList;
		}
		public int CalculateAge(DateTime dob)
		{
			DateTime today = DateTime.Today;
			int age = today.Year - dob.Year;
			if (dob > today.AddYears(-age))
			{
				age--;
			}
			return age;
		}
		public List<TopColoursDTO> GetTopColours(List<UserEntity>? userList)
		{
			List<TopColoursDTO> coloursDTO = new List<TopColoursDTO>();

			foreach (var coloursList in userList.GroupBy(info => info.favouriteColour)
						.Select(group => new
						{
							Colour = group.Key,
							Count = group.Count()
						})
						.OrderByDescending(x => x.Count)
						.ThenBy(x => x.Colour)
						)
			{
				TopColoursDTO colour = new TopColoursDTO();
				colour.colour = coloursList.Colour;
				colour.count = coloursList.Count;
				coloursDTO.Add(colour);
			}

			return coloursDTO;
		}
	}
}
