namespace FrontEnd.Server.Tests
{
using FrontEnd.Server.Services;

public class UserEntityServicesTests
	{
	private readonly IUserEntityService _userEntityService;

		 /// <summary>
		 /// This is the main tests, there are obviously many other tests I could include in here using Moq to impersonate expected data and classes.
		 /// </summary>
		 public UserEntityServicesTests()
		{
			_userEntityService = new UserEntityService();
		}
		
		[Theory]
		[InlineData("1965-06-26T00:00:00",58)]
		[InlineData("1912-12-06T00:00:00",111)]
		public void When_Given_a_DOB_And_Age_Returns_Match(string dob,int realAge)
		{
			var age = _userEntityService.CalculateAge(DateTime.Parse(dob));
			Assert.Equal(realAge, age);
		}
	}
}