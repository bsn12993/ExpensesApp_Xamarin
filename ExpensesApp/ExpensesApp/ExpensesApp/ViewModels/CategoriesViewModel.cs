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
        #region Properties
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
        #endregion

        #region Attributes
        public ObservableCollection<CategoryItemViewModel> categories;
        #endregion

        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public CategoriesViewModel()
        {
            //MainViewModel.GetInstance().LoadCategories();
            this.Categories = new ObservableCollection<CategoryItemViewModel>(ToCategoryItemViewModel());
        }
        #endregion

        #region Methods
        public IEnumerable<CategoryItemViewModel> ToCategoryItemViewModel()
        {
            return MainViewModel.GetInstance().Categories.Select(c => new CategoryItemViewModel
            {
                Category_Id = c.Category_Id,
                Name = c.Name
            });
        }
        #endregion
    }
}
