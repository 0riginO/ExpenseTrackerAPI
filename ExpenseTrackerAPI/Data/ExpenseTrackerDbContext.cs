using Microsoft.EntityFrameworkCore;
using ExpenseTrackerAPI.Models;

namespace ExpenseTrackerAPI.Data
{
	public class ExpenseTrackerDbContext : DbContext
	{
		// Constructor that passes the options to the base DbContext class
		public ExpenseTrackerDbContext(DbContextOptions<ExpenseTrackerDbContext> options) : base(options) { }

		// Called by EF Core to configure the model
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			// Seeding initial data into the table
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Expense>().HasData(
				new Expense { Id = 1, Name = "Office Supplies", Amount = 100, DateAdded = new DateTime(2023, 1, 1) },
				new Expense { Id = 2, Name = "Travel", Amount = 500, DateAdded = new DateTime(2023, 2, 15) },
				new Expense { Id = 3, Name = "Meals", Amount = 200, DateAdded = new DateTime(2023, 3, 10) }
			);
		}

		// Represents the Expenses table in the database
		public DbSet<Expense> Expenses { get; set; }
	}
}
