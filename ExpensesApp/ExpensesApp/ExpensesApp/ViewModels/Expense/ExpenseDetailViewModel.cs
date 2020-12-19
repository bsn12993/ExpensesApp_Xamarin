using ExpensesApp.Models.Expense;
using System.ComponentModel;

namespace ExpensesApp.ViewModels
{
    public class ExpenseDetailViewModel : INotifyPropertyChanged
    {
        #region Properties
        public string Amount
        {
            get { return this.amount; }
            set
            {
                if (this.amount != value)
                {
                    this.amount = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Amount)));
                }
            }
        }

        public string Category
        {
            get { return this.category; }
            set
            {
                if (this.category != value)
                {
                    this.category = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Category)));
                }
            }
        }

        public string Date
        {
            get { return this.date; }
            set
            {
                if (this.date != value)
                {
                    this.date = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Date)));
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

        public ExpenseDetailViewModel(ExpenseList expense)
        {
            this.Category = expense.Category;
            this.Date = expense.Date;
            this.Amount = expense.Amount.ToString();
        }
        #endregion
    }
}
