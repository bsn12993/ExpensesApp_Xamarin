using ExpensesApp.Models.Category;
using System.Collections.Generic;

namespace ExpensesApp.Services.Category
{
    public class CategoryService 
    {
        #region Constructor
        private CategoryService()
        {

        }
        #endregion

        #region Attributes
        private static CategoryService instance;
        #endregion

        #region Methods
        public static CategoryService GetInstance()
        {
            if (instance == null) instance = new CategoryService();
            return instance;
        } 

        public List<CategoryItem> FindAll()
        {
            var list = new List<CategoryItem>();
            for(int i = 0; i < 15; i++)
            {
                list.Add(new CategoryItem
                {
                    Id = i,
                    Name = $"Categoría {i}",
                    UserId = i
                });
            }
            return list;
        }
        #endregion
    }
}
