using Microsoft.EntityFrameworkCore;

namespace BrowserServerSingnalR.Repository
{
	public class MyDbContext: DbContext
	{
		public DbSet<WeatherForecast> WeatherForecasts { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			ServerVersion version = new MySqlServerVersion(new Version(8, 0, 35));
			string connectStr = "server=localhost;user=root;password=LuoHao@123;database=test";
			optionsBuilder.UseMySql(connectStr, version);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<WeatherForecast>().ToTable("T_WeatherForecast");
			modelBuilder.Entity<WeatherForecast>().HasKey("Id");
			modelBuilder.Entity<WeatherForecast>().Property(p => p.Id).ValueGeneratedOnAdd();
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(WeatherForecast).Assembly);
		}
	}
}
