using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Data.EntityModel
{
    public class Income
    {
        public int Income_Id { get; set; }
        public DateTime Date { get; set; }
        public int User_Id { get; set; }

        public User User { get; set; }
    }
}
