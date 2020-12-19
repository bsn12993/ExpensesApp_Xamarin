namespace ExpensesApp.Models
{
    public class CreateExpense
    {
        public string ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
