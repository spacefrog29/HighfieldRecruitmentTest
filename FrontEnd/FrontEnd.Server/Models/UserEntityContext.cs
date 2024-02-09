using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace FrontEnd.Server.Models
{
	public class UserEntityContext : DbContext
	{
		public UserEntityContext(DbContextOptions<UserEntityContext> options) : base(options)
		{ }

		public DbSet<UserEntity> UserEntities { get; set; }
	}
}
