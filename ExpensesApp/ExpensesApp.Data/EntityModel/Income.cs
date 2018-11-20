using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Data.EntityModel
{
    [Table("Incomes")]
    public class Income
    {
        [Column("idincome")]
        [Key]
        public int Income_Id { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [ForeignKey("User")]
        public int User_Id { get; set; }

        [Column("iduser")]
        public User User { get; set; }
    }
}
