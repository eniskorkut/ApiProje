using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace ApiProjeKampi.WebApi.Context
{
	public class ApiContextFactory : IDesignTimeDbContextFactory<ApiContext>
	{
		public ApiContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<ApiContext>();
			var envConn =
				Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection") ??
				Environment.GetEnvironmentVariable("DEFAULT_CONNECTION") ??
				Environment.GetEnvironmentVariable("CONNECTION_STR");

			if (string.IsNullOrWhiteSpace(envConn))
			{
				throw new InvalidOperationException(
					"Connection string not found for design-time factory. Set env var 'ConnectionStrings__DefaultConnection' or 'DEFAULT_CONNECTION'.");
			}

			optionsBuilder.UseNpgsql(envConn);

			return new ApiContext(optionsBuilder.Options);
		}
	}
} 