using ExpensesApp.Models;
using ExpensesApp.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

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

        public ExpenseDetailViewModel(Expense expense)
        {
            this.Category = expense.Category.Name;
            this.Date = expense.Date;
            this.Amount = expense.Amount.ToString();
        }
        #endregion
    }
}
