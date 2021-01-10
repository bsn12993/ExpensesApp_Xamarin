using ExpensesApp.Models.Expense;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ExpensesApp.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ObservableCollection<ExpenseItem> Expenses
        {
            get { return expenses; }
            set
            {
                if (expenses != value)
                {
                    expenses = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Expenses)));
                }
            }
        }

        public string Total
        {
            get { return total; }
            set
            {
                if (total != value)
                {
                    total = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
                }
            }
        }

        public bool IsRunning
        {
            get { return isRunning; }
            set
            {
                if (isRunning != value)
                {
                    isRunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRunning)));
                }
            }
        }
        #endregion

        #region Attributes
        private ObservableCollection<ExpenseItem> expenses;
        private string total;
        private bool isRunning;
        #endregion

        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public HomeViewModel()
        {
            //LoadCategories();
            //LoadTotal();
        }
        #endregion

        #region Commands
        public ICommand AddIncomePageCommand
        {
            get { return new RelayCommand(AddIncomePage); }
        }      
        #endregion

        #region Methods
        public async void LoadTotal()
        {
            /*
            this.IsRunning = true;
            var connection = await ApiServices.GetInstance().CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Ok");
                return;
            }
            var total = await ApiServices.GetInstance().GetItem<string>
                ($"api/incomes/total/byuser/{MainViewModel.GetInstance().GetUser.User_Id}");
            if (!total.IsSuccess)
            {
                this.IsRunning = false;
                return;
            }

            this.IsRunning = false;
            this.Total = "11";
            */
            this.Total = "11";
        }

        public async void LoadCategories()
        {
            /*
            var category = await ApiServices.GetInstance().GetList<Category>("api/category/all");
            if (!category.IsSuccess)
            {
                return;
            }
            this.Expenses = new ObservableCollection<ExpensesEnc>();
            if (category != null)
            {
                var lst = (List<Category>)category.Result;
                foreach (var i in lst)
                {
                    this.Expenses.Add(new Models.ExpensesEnc
                    {
                        Category = new Category { Name = i.Name },
                        Total = 11M
                    });
                }
            }
            */
            this.Expenses = new ObservableCollection<ExpenseItem>();
            for (int i = 1; i <= 10; i++)
            {
                this.Expenses.Add(new ExpenseItem
                {
                    Category = $"Cat {i}",
                    Amount = 11M
                });
            }
        }

        private void AddIncomePage()
        {
            if (MainViewModel.GetInstance().IncomeListViewModel == null)
                MainViewModel.GetInstance().IncomeListViewModel = new IncomeListViewModel();
            MainViewModel.GetInstance().IncomeListViewModel.LoadIncomeList();
            App.Navigator.PushAsync(new IncomeListPage());
        }
        #endregion
    }
}
