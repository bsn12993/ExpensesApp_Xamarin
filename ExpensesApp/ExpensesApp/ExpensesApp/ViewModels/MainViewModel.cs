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
        public CategoryViewModel CategoryItem { get; set; }
        public HomeViewModel Home { get; set; }
        public ExpenseViewModel Expense { get; set; }
        public ExpensesViewModel Expenses { get; set; }
        public CategoriesViewModel Category { get; set; }

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
            Category = new CategoriesViewModel();
            Expenses = new ExpensesViewModel();
            this.LoadMenu();
        }

        public void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuItemViewModel>();
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "",
                PageName = "HomePage",
                Title = "Dashboard"
            });
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "",
                PageName = "ExpensesPage",
                Title = "Gastos"
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
                PageName = "CategoriesPage",
                Title = "Categorias"
            });
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "",
                PageName = "HistoryPage",
                Title = "Historial"
            });
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "",
                PageName = "ProfilePage",
                Title = "Perfil"
            });
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "",
                PageName = "LoginPage",
                Title = "Salir"
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
