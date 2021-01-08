using ExpensesApp.Models;
using ExpensesApp.Models.Category;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ExpensesApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Properties
        public LoginViewModel LoginViewModel { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
        public ObservableCollection<MenuItemViewModel> MenuItemView { get; set; }

        #region Category
        public CategoryItemViewModel CategoryItemViewModel { get; set; }
        public CategoryListViewModel CategoryListViewModel { get; set; }
        #endregion

        #region Expense
        public ExpenseDetailViewModel ExpenseDetailViewModel { get; set; }
        public ExpenseListViewModel ExpenseListViewModel { get; set; }
        public AddExpenseViewModel AddExpenseViewModel { get; set; }
        #endregion

        #region Income
        public AddIncomeViewModel AddIncomeViewModel { get; set; }
        public IncomeListViewModel IncomeListViewModel { get; set; }
        #endregion

        public HomeViewModel HomeViewModel { get; set; }
        public ProfileViewModel ProfileViewModel { get; set; }
        public HistoryExpensesViewModel HistoryExpenses { get; set; }
         
        public FindUser GetUser
        {
            get { return getUser; }
            set
            {
                if (getUser != value)
                {
                    getUser = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GetUser)));
                }
            }
        }
        #endregion

        private FindUser getUser;

        #region Singleton
        private static MainViewModel instance;

        public event PropertyChangedEventHandler PropertyChanged;

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
            LoginViewModel = new LoginViewModel();
            RegisterViewModel = new RegisterViewModel();
            AddIncomeViewModel = new AddIncomeViewModel();
            ProfileViewModel = new ProfileViewModel();
            LoadMenu();
        }
        #endregion

        #region Methods
        public void LoadMenu()
        {
            MenuItemView = new ObservableCollection<MenuItemViewModel>();
            MenuItemView.Add(new MenuItemViewModel
            {
                Icon = "ic_home",
                PageName = "HomePage",
                Title = "Dashboard"
            });
            MenuItemView.Add(new MenuItemViewModel
            {
                Icon = "ic_list",
                PageName = "ExpenseListPage",
                Title = "Gastos"
            });
            MenuItemView.Add(new MenuItemViewModel
            {
                Icon = "ic_list",
                PageName = "CategoryListPage",
                Title = "Categorias"
            });
            MenuItemView.Add(new MenuItemViewModel
            {
                Icon = "ic_history",
                PageName = "HistoryExpensesPage",
                Title = "Historial Gastos"
            });
            MenuItemView.Add(new MenuItemViewModel
            {
                Icon = "ic_history",
                PageName = "IncomeListPage",
                Title = "Ingresos"
            });
            MenuItemView.Add(new MenuItemViewModel
            {
                Icon = "ic_info",
                PageName = "ProfilePage",
                Title = "Perfil"
            });
            MenuItemView.Add(new MenuItemViewModel
            {
                Icon = "ic_close",
                PageName = "LoginPage",
                Title = "Salir"
            });
        }
        #endregion
    }
}
