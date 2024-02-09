using FrontEnd.Server.Models;

namespace HighFieldTest.Server.Models
{
	public class ResponseDTO
	{
		public UserEntity? users { get; set; }
		public AgePlusTwentyDTO? ages { get; set; }
		public TopColoursDTO? topColours { get; set; }
	}
}
