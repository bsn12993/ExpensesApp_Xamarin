namespace ExpensesApp.Models.Category
{
    public class CategoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = "AA";
        public int UserId { get; set; }
    }
}
