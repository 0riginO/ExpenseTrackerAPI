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

		// HTTP GET endpoint to retrieve a single expense by its ID
		// Route: GET api/expenses/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<Expense>> GetExpenseById(int id)
		{
			// Attempt to find the expense in the database by its primary key
			var expense = await _context.Expenses.FindAsync(id);

			// If no matching expense is found, return a 404 Not Found response
			if (expense == null)
				return NotFound();

			// If found, return the expense (automatically serialized to JSON)
			return expense;
		}

		// HTTP POST endpoint to add a new expense
		// Route: POST api/expenses
		[HttpPost]
		public async Task<ActionResult<Expense>> AddExpense(Expense newExpense)
		{
			// Validate input: return 400 Bad Request if the incoming expense object is null
			if (newExpense == null)
				return BadRequest();

			// Add the new expense to the EF Core change tracker
			_context.Expenses.Add(newExpense);

			// Save the changes asynchronously to the database
			await _context.SaveChangesAsync();

			// Return 201 Created response with a Location header pointing to the new resource
			// This uses GetExpenseById to generate the URL to the new item
			return CreatedAtAction(nameof(GetExpenseById), new { id = newExpense.Id }, newExpense);
		}

		// HTTP PUT endpoint to update an existing expense
		// Route: PUT api/expenses/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateExpense(int id, Expense updatedExpense)
		{
			// Check if the incoming expense object is null
			// If so, return 400 Bad Request with a message
			if (updatedExpense == null)
				return BadRequest("Invalid expense data.");

			// Try to find the existing expense in the database by ID
			var expense = await _context.Expenses.FindAsync(id);

			// If not found, return 404 Not Found
			if (expense == null)
				return NotFound();

			// Update the existing expense with new values
			expense.Name = updatedExpense.Name;
			expense.Amount = updatedExpense.Amount;

			// Save the changes to the database asynchronously
			await _context.SaveChangesAsync();

			// Return 204 No Content to indicate the update was successful
			return NoContent();
		}
	}
}
