using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesApp.Models
{
    public class Expense
    {
        public int id_Expense { get; set; }
        public Category Category { get; set; }
        public decimal Amount { get; set; } 
        public string Date { get; set; }
        public int Category_Id { get; set; }
        public int User_Id { get; set; }
    }
}
