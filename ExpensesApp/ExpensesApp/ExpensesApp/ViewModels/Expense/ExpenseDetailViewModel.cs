using ExpensesApp.Models.Expense;
using System.ComponentModel;

namespace ExpensesApp.ViewModels
{
    public class ExpenseDetailViewModel : INotifyPropertyChanged
    {
        #region Properties
        public string Amount
        {
            get { return amount; }
            set
            {
                if (amount != value)
                {
                    amount = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Amount)));
                }
            }
        }

        public string Category
        {
            get { return category; }
            set
            {
                if (category != value)
                {
                    category = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Category)));
                }
            }
        }

        public string Date
        {
            get { return date; }
            set
            {
                if (date != value)
                {
                    date = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Date)));
                }
            }
        }
        #endregion

        #region Attributes
        private string amount;
        private string category;
        private string date;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public ExpenseDetailViewModel()
        {
        }

        public ExpenseDetailViewModel(ExpenseItem expense)
        {
            this.Category = expense.Category;
            this.Date = expense.Date;
            this.Amount = expense.Amount.ToString();
        }
        #endregion
    }
}
