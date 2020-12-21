namespace ExpensesApp.Services.User
{
    public class UserService
    {
        #region Constructor
        private UserService()
        {

        }
        #endregion

        #region Attributes
        private UserService instance;
        #endregion

        #region Methods
        public UserService GetInstance()
        {
            if (instance == null) instance = new UserService();
            return instance;
        }
        #endregion
    }
}
