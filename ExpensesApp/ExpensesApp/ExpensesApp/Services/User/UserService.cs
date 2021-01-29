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
                    .Create($"api/users/validate", login);
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Response> Create(CreateUser createUser)
        {
            try
            {
                var response = await ApiService
                    .GetInstance()
                    .Create("api/user/create", createUser);
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Response> Update(UpdateUser updateUser)
        {
            try
            {
                var response = await ApiService
                    .GetInstance()
                    .Update("api/user/update", updateUser, updateUser.Id);
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
