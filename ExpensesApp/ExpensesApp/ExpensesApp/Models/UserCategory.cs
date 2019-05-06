using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesApp.Models
{
    public class UserCategory
    {
        public int UserCategory_Id { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
    }
}
