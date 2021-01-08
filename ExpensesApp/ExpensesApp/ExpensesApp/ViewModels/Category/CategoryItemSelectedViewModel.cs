using ExpensesApp.Models.Category;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace ExpensesApp.ViewModels
{
    public class CategoryItemSelectedViewModel : CategoryItem
    {
        #region Properties
        public ICommand SelectCategoryCommand
        {
            get { return new RelayCommand(SelectCategory); }
        }
        #endregion

        #region Methods
        private void SelectCategory()
        {
            CategoryItem category = this;
            MainViewModel.GetInstance().CategoryItemViewModel = new CategoryItemViewModel(category);
            App.Navigator.PushAsync(new EditCategoryPage());
        }
        #endregion
    }
}
