using ExpensesApp.Models;
using ExpensesApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

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
        public ExpenseDetailViewModel ExpenseDetail { get; set; }
        public ExpensesViewModel Expenses { get; set; }
        public ExpenseViewModel Expense { get; set; }
        public CategoriesViewModel Category { get; set; }
        public IncomeViewModel Income { get; set; }
        public ProfileViewModel Profile { get; set; }
        public HistoryExpensesViewModel HistoryExpenses { get; set; }
        public HistoryIncomesViewModel HistoryIncomes { get; set; }
        public User GetUser { get; set; }
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
            //Expense = new ExpenseViewModel();
            //Home = new HomeViewModel();
            //Category = new CategoriesViewModel();
            //Expense = new ExpenseViewModel();
            Income = new IncomeViewModel();
            Profile = new ProfileViewModel();
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
            //this.Menu.Add(new MenuItemViewModel
            //{
            //    Icon = "ic_add",
            //    PageName = "IncomePage",
            //    Title = "Agregar Ingreso"
            //});
            //this.Menu.Add(new MenuItemViewModel
            //{
            //    Icon = "ic_add",
            //    PageName = "AddExpensePage",
            //    Title = "Agregar Gastos"
            //});
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_list",
                PageName = "CategoriesPage",
                Title = "Categorias"
            });
            //this.Menu.Add(new MenuItemViewModel
            //{
            //    Icon = "ic_add",
            //    PageName = "AddCategoryPage",
            //    Title = "Agregar Categoria"
            //});
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_history",
                PageName = "HistoryExpensesPage",
                Title = "Historial Gastos"
            });
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_history",
                PageName = "HistoryIncomesPage",
                Title = "Historial Ingresos"
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
        #endregion
    }
}
