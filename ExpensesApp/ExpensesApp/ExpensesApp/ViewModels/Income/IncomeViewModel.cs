using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Input;

namespace ExpensesApp.ViewModels
{
    public class IncomeViewModel : INotifyPropertyChanged
    {
        #region Properties
        public string Income
        {
            get { return this.income; }
            set
            {
                if (this.income != value)
                {
                    this.income = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Income)));
                }
            }
        }
        
        public bool IsRunning
        {
            get { return this.isRunning; }
            set
            {
                if (this.isRunning != value)
                {
                    this.isRunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsRunning)));
                }
            }
        }
        #endregion

        #region Attributes
        private string income;
        private bool isRunning;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Commands
        public ICommand SaveIncomeCommand
        {
            get { return new RelayCommand(SaveIncome); }
        }
        #endregion

        #region Methods
        private async void SaveIncome()
        {
            /*
            this.IsRunning = true;
            var income = new Income
            {
                Amount = Convert.ToDecimal(this.Income),
                Date = DateTime.Now.ToShortDateString(),
                User_Id = MainViewModel.GetInstance().GetUser.User_Id
            };

            var connection = await ApiServices.GetInstance().CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Ok");
                return;
            }

            var registerIncome = await ApiServices.GetInstance().PostItem("api/incomes/create", income);
            if (!registerIncome.IsSuccess)
            {
                this.IsRunning = false;
                return;
            }

            this.IsRunning = false;
            MainViewModel.GetInstance().Home.LoadTotal();
            await Application.Current.MainPage.DisplayAlert("Ok", "Income", "Accept");
            this.Income = string.Empty;
            if (MainViewModel.GetInstance().HistoryIncomes == null)
                MainViewModel.GetInstance().HistoryIncomes = new HistoryIncomesViewModel();
            MainViewModel.GetInstance().HistoryIncomes.LoadIncomesHistory();
            */
        }
        #endregion
    }
}
