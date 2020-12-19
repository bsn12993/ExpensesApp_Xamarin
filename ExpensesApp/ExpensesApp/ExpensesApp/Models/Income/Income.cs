namespace ExpensesApp.Models
{
    public class Income
    {
        public int Income_Id { get; set; }
        public string Date { get; set; }
        public decimal Amount { get; set; }
        public int User_Id { get; set; }
        public FindUser User { get; set; }
    }
}
