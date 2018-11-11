using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExpensesApp.ViewModels
{
    public class MainViewModel
    {
        public LoginViewModel Login { get; set; }
        public RegisterViewModel Register { get; set; }
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public HomeViewModel Home { get; set; }
        public ExpenseViewModel Expense { get; set; }
        public CategoryViewModel Category { get; set; }

        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null) return new MainViewModel();
            else return instance;
        }

        public MainViewModel()
        {
            instance = this;
            Login = new LoginViewModel();
            Register = new RegisterViewModel();
            Expense = new ExpenseViewModel();
            Home = new HomeViewModel();
            Category = new CategoryViewModel();
            this.LoadMenu();
        }

        public void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuItemViewModel>();
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "",
                PageName = "",
                Title = "Dashboard"
            });
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "",
                PageName = "AddExpensePage",
                Title = "Agregar Gastos"
            });
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "",
                PageName = "CategoryPage",
                Title = "Categorias"
            });
        }

        public void LoadCategories()
        {
            this.Categories = new ObservableCollection<Category>();
            this.Categories.Add(new Category
            {
                Name = "Gasolina"
            });
            this.Categories.Add(new Category
            {
                Name = "Comida"
            });
            this.Categories.Add(new Category
            {
                Name = "Vestido"
            });
            this.Categories.Add(new Category
            {
                Name = "Casa"
            });
        }

    }
}
