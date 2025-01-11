using intro_Address_CRUD_Exam.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace intro_Address_CRUD_Exam.Context
{
	public class DataContext : DbContext
	{

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<Country> Country { get; set; }
		public DbSet<Address> Address { get; set; }
		public DbSet<City> City { get; set; }
		public DbSet<Ilce> Ilce { get; set; }
	}
}
