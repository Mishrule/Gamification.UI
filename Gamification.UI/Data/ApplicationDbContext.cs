using Microsoft.EntityFrameworkCore;

namespace Gamification.UI.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
				: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Tasks>()
					.HasKey(ci => new { ci.Id });

			modelBuilder.Entity<TasksResponse>()
					.HasKey(p => new { p.Id });

			//modelBuilder.Entity<OrderItem>()
			//    .HasKey(oi => new { oi.OrderId, oi.ProductId, oi.ProductTypeId });

			modelBuilder.Entity<Tasks>().HasData(
							new Tasks { Id = 1, Description = "click on complete for 5 points double click for 10 points", StepNumber = "Step 1" },
							 new Tasks { Id = 2, Description = "click on complete for 5 points double click for 10 points", StepNumber = "Step 2" },
								new Tasks { Id = 3, Description = "click on complete for 5 points double click for 10 points", StepNumber = "Step 3" },
								 new Tasks { Id = 4, Description = "click on complete for 5 points double click for 10 points", StepNumber = "Step 4" },
									new Tasks { Id = 5, Description = "click on complete for 5 points double click for 10 points", StepNumber = "Step 5" }
					);
		}



		public DbSet<Tasks> Tasks { get; set; }
		public DbSet<TasksResponse> Responses { get; set; }
	}


}
