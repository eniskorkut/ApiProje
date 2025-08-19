using System;
using Microsoft.EntityFrameworkCore;
using ApiProjeKampi.WebApi.Entities;
using System;

namespace ApiProjeKampi.WebApi.Context
{
	public class ApiContext : DbContext
	{
		public ApiContext(DbContextOptions<ApiContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var envConn =
					Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection") ??
					Environment.GetEnvironmentVariable("DEFAULT_CONNECTION") ??
					Environment.GetEnvironmentVariable("CONNECTION_STR");

				if (string.IsNullOrWhiteSpace(envConn))
				{
					throw new InvalidOperationException(
						"Connection string not found. Set environment variable 'ConnectionStrings__DefaultConnection' or 'DEFAULT_CONNECTION' or provide options in AddDbContext.");
				}

				optionsBuilder.UseNpgsql(envConn);
			}
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Chef> Chefs { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Feature> Features { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<Testimonial> Testimonials { get; set; }
	}
}