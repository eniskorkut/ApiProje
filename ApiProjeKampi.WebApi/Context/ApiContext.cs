using System;
using Microsoft.EntityFrameworkCore;
using ApiProjeKampi.WebApi.Entities;

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
				optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ApiProjeKampiDb;User Id=postgres;Password=123456em;");
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