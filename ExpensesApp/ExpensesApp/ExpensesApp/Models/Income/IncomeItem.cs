using System;

namespace ExpensesApp.Models
{
    public class IncomeItem
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public int UserId { get; set; }
    }
}
