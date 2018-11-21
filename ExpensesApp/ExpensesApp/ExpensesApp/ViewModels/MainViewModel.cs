using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExpensesApp.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public LoginViewModel Login { get; set; }
        public RegisterViewModel Register { get; set; }
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public CategoryViewModel CategoryItem { get; set; }
        public HomeViewModel Home { get; set; }
        public ExpenseViewModel Expense { get; set; }
        public ExpensesViewModel Expenses { get; set; }
        public CategoriesViewModel Category { get; set; }
        public IncomeViewModel Income { get; set; }
        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null) return new MainViewModel();
            else return instance;
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            Login = new LoginViewModel();
            Register = new RegisterViewModel();
            Expense = new ExpenseViewModel();
            Home = new HomeViewModel();
            Category = new CategoriesViewModel();
            Expenses = new ExpensesViewModel();
            Income = new IncomeViewModel();
            this.LoadMenu();
        }
        #endregion

        #region Methods
        public void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuItemViewModel>();
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_home",
                PageName = "HomePage",
                Title = "Dashboard"
            });
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_list",
                PageName = "ExpensesPage",
                Title = "Gastos"
            });
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_add",
                PageName = "IncomePage",
                Title = "Agregar Ingreso"
            });
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_add",
                PageName = "AddExpensePage",
                Title = "Agregar Gastos"
            });
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_list",
                PageName = "CategoriesPage",
                Title = "Categorias"
            });
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_history",
                PageName = "HistoryPage",
                Title = "Historial"
            });
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_info",
                PageName = "ProfilePage",
                Title = "Perfil"
            });
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_close",
                PageName = "LoginPage",
                Title = "Salir"
            });
        }

        public void LoadCategories()
        {
            this.Categories = new ObservableCollection<Category>();
            this.Categories.Add(new Category
            {
                Id_Category = 1,
                Name = "Gasolina"
            });
            this.Categories.Add(new Category
            {
                Id_Category = 2,
                Name = "Comida"
            });
            this.Categories.Add(new Category
            {
                Id_Category = 3,
                Name = "Vestido"
            });
            this.Categories.Add(new Category
            {
                Id_Category = 4,
                Name = "Casa"
            });
        }
        #endregion
    }
}
