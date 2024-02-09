using HighFieldTest.Server.Models;

namespace FrontEnd.Server.Models
{
	public class UserEntity
	{
		public Guid id { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string email { get; set; }
		public DateTime dob { get; set; }
		public string favouriteColour { get; set; }
		public int age { get; set; }
		public int ageplus20 { get; set; }
	}
}
