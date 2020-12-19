namespace ExpensesApp.Models.Expense
{
    public class UpdateExpense
    {
        public int Id { get; set; }
        public string ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
