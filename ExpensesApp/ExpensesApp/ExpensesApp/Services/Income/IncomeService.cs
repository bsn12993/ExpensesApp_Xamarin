namespace ExpensesApp.Services.Income
{
    public class IncomeService
    {
        #region Constructor
        private IncomeService()
        {

        }
        #endregion

        #region Attributes
        private IncomeService instance;
        #endregion

        #region Methods
        public IncomeService GetInstance()
        {
            if (instance == null) instance = new IncomeService();
            return instance;
        }
        #endregion
    }
}
