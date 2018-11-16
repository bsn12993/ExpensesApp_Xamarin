using ExpensesApp.Models;
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
    public class ExpenseViewModel : INotifyPropertyChanged
    {
        public string Mount
        {
            get { return this.mount; }
            set
            {
                if (this.mount != value)
                {
                    this.mount = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Mount)));
                }
            }
        }

        public Category CategoySelected
        {
            get { return this.categoySelected; }
            set
            {
                if (this.categoySelected != value)
                {
                    this.categoySelected = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.categoySelected)));
                }
            }
        }

        public ObservableCollection<Category> Categories { get; set; }

        private string mount;
        private Category categoySelected;
        public event PropertyChangedEventHandler PropertyChanged;  

        public ExpenseViewModel()
        {
            MainViewModel.GetInstance().LoadCategories();
            this.Categories = MainViewModel.GetInstance().Categories;
        }

        public ICommand SaveExpenseCommand
        {
            get { return new RelayCommand(SaveExpense); }
        }

        private async void SaveExpense()
        {
            if(!string.IsNullOrEmpty(this.mount) && !string.IsNullOrEmpty(this.CategoySelected.Name))
            {
                await Application.Current.MainPage.DisplayAlert("OK", "se agrego un nuevo gasto", "Accept");
                this.Mount = string.Empty;
                this.CategoySelected.Name = string.Empty;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se permiten campos vacios", "Accept");
            }
        }


        public ExpenseViewModel(Expense expense)
        {
            MainViewModel.GetInstance().LoadCategories();
            this.Categories = MainViewModel.GetInstance().Categories;
            this.Mount = expense.Mount.ToString();
        }
    }
}
