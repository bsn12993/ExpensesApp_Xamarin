using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Data.EntityModel
{
    [Table("Users")]
    public class User
    {
        [Column("iduser")]
        [Key]
        public int User_Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("lastName")]
        public string LastName { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("email")]
        public string Email { get; set; }
    }
}
