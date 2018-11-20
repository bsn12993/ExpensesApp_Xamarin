using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Data.EntityModel
{
    public class Expense
    {
        public int Expense_Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Mount { get; set; }
        public int Category_Id { get; set; }
        public int User_Id { get; set; }

        public Category Category { get; set; }
        public User User { get; set; }
    }
}
