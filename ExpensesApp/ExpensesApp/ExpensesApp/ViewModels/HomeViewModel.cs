using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExpensesApp.ViewModels
{
    public class HomeViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }

        public HomeViewModel()
        {
           
        }

        public void LoadCategories()
        {
            this.Categories = new ObservableCollection<Category>();
            this.Categories.Add(new Category
            {
                Name = "Gasolina",
                Total = 100.00M
            });
            this.Categories.Add(new Category
            {
                Name = "Comida",
                Total = 100.00M
            });
            this.Categories.Add(new Category
            {
                Name = "Vestido",
                Total = 100.00M
            });
            this.Categories.Add(new Category
            {
                Name = "Casa",
                Total = 100.00M
            });
        }
    }
}
