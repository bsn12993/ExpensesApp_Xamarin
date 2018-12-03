using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesApp.Models
{
    public class Income
    {
        public int Income_Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int User_Id { get; set; }
        public User User { get; set; }
    }
}
