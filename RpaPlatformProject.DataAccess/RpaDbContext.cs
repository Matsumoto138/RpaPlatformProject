using Microsoft.EntityFrameworkCore;
using RpaPlatformProject.Entity;

namespace RpaPlatformProject.DataAccess
{
	public class RpaDbContext : DbContext
	{
		public RpaDbContext(DbContextOptions<RpaDbContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Robot> Robots { get; set; }
		public DbSet<Schedule> Schedules { get; set; }
		public DbSet<Log> Logs { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
			   .HasMany(u => u.Robots)
			   .WithOne(r => r.User)
			   .HasForeignKey(r => r.UserId);

			modelBuilder.Entity<Robot>()
				.HasMany(r => r.Schedules)
				.WithOne(s => s.Robot)
				.HasForeignKey(s => s.RobotId);

			modelBuilder.Entity<Robot>()
				.HasMany(r => r.Logs)
				.WithOne(l => l.Robot)
				.HasForeignKey(l => l.RobotId);

			base.OnModelCreating(modelBuilder);
		}
	}
}
