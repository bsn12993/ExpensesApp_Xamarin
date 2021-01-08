using ExpensesApp.Exceptions;
using Plugin.Connectivity;
using System;
using System.Threading.Tasks;

namespace ExpensesApp.Helpers
{
    public class InternetConnectionHelper
    {
        private InternetConnectionHelper()
        {

        }

        private static InternetConnectionHelper instance;

        public static InternetConnectionHelper GetInstance()
        {
            if (instance == null) instance = new InternetConnectionHelper();
            return instance;
        }

        public void CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                throw new NoInternetConnectionException("Please turn on your internet settings.");
            }

            //var isReachable = await CrossConnectivity.Current.IsReachable("motzcod.es");
            //if (!isReachable)
            //{
            //    return new Response
            //    {
            //        IsSuccess = false,
            //        Message = "check you internet connection."
            //    };
            //}
        }
    }
}
