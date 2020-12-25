using ExpensesApp.Models;
using ExpensesApp.Models.User;
using System;
using System.Threading.Tasks;

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
        private static UserService instance;
        #endregion

        #region Methods
        public static UserService GetInstance()
        {
            if (instance == null) instance = new UserService();
            return instance;
        }

        public async Task<Response> Login(string email, string password)
        {
            try
            {
                var login = new LoginUser
                {
                    Email = email,
                    Password = password
                };
                var response = await ApiService
                    .GetInstance()
                    .Create<LoginUser>($"api/users/validate", login);
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
