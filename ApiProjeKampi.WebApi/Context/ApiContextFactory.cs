using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ApiProjeKampi.WebApi.Context
{
	public class ApiContextFactory : IDesignTimeDbContextFactory<ApiContext>
	{
		public ApiContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<ApiContext>();
			optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ApiProjeKampiDb;User Id=postgres;Password=123456em;");

			return new ApiContext(optionsBuilder.Options);
		}
	}
} 