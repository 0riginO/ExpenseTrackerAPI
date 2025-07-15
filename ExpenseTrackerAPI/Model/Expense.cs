namespace ExpenseTrackerAPI.Model
{
	public class Expense
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public decimal Amount { get; set; }
		public DateTime DateAdded { get; set; }
	}

}
