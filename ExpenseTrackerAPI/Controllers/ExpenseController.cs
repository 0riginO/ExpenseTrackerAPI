using Microsoft.AspNetCore.Mvc;
using ExpenseTrackerAPI.Models;
using ExpenseTrackerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Controllers
{
	// Marks this class as an API controller
	[ApiController]
	// Sets the route for this controller: "api/expenses"
	[Route("api/[controller]")]
	public class ExpensesController : ControllerBase
	{
		// Dependency injection of the database context
		private readonly ExpenseTrackerDbContext _context;

		// Constructor that receives the database context via DI
		public ExpensesController(ExpenseTrackerDbContext context)
		{
			_context = context;
		}

		// HTTP GET endpoint to retrieve all expenses
		// Route: GET api/expenses
		[HttpGet]
		public async Task<ActionResult<List<Expense>>> GetExpenses()
		{
			// Fetches all expenses asynchronously from the database
			return Ok(await _context.Expenses.ToListAsync());
		}
	}
}
