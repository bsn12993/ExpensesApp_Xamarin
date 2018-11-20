using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Data.EntityModel
{
    [Table("Categories")]
    public class Category
    {
        [Column("idcategory")]
        [Key]
        public int Category_Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("status")]
        public int Status { get; set; }
    }
}
