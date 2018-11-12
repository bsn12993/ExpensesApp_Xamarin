using ExpensesApp.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class CategoriesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CategoryItemViewModel> Categories
        {
            get { return this.categories; }
            set
            {
                if (this.categories != value)
                {
                    this.categories = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Categories)));
                }
            }
        }

        public ObservableCollection<CategoryItemViewModel> categories;

        public event PropertyChangedEventHandler PropertyChanged;

        public CategoriesViewModel()
        {
            MainViewModel.GetInstance().LoadCategories();
            this.Categories = new ObservableCollection<CategoryItemViewModel>(ToCategoryItemViewModel());
        }

        public IEnumerable<CategoryItemViewModel> ToCategoryItemViewModel()
        {
            return MainViewModel.GetInstance().Categories.Select(c => new CategoryItemViewModel
            {
                Id_Category = c.Id_Category,
                Name = c.Name
            });
        }

    }
}
