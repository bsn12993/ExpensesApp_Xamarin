namespace ExpensesApp.Models
{
    public class User
    {
        public int User_Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", this.Name, this.LastName); }
        }

        public override int GetHashCode()
        {
            return this.User_Id;
        }
    }
}
