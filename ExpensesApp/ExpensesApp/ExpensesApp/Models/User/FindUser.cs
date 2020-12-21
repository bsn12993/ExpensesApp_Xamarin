﻿namespace ExpensesApp.Models
{
    public class FindUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }


        public string FullName
        {
            get { return string.Format("{0} {1}", this.Name, this.LastName); }
        }

         
    }
}
