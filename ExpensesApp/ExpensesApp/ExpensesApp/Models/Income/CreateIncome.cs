namespace ExpensesApp.Models.Income
{
    public class CreateIncome
    {
        public string Date { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
    }
}
