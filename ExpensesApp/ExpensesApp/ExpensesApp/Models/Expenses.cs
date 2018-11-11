using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesApp.Models
{
    public class Expenses
    {
        public Category Category { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
    }
}
