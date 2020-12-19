﻿namespace ExpensesApp.Models.Expense
{
    public class ExpenseList
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
