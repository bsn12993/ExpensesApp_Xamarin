using ExpensesApp.Exceptions;
using ExpensesApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Services
{
    public class ApiService : HttpClient
    {
        #region Constructors
        private ApiService() : base()
        {
            Timeout = TimeSpan.FromMilliseconds(15000);
            MaxResponseContentBufferSize = 256000;
            var baseURLl = Xamarin.Forms.Application.Current.Resources["UrlAPI"].ToString();
            BaseAddress = new Uri(baseURLl);
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        #region Singleton
        private static readonly ApiService instance = new ApiService();
        static ApiService() { }
        public static ApiService GetInstance()
        {
            if (instance == null) return new ApiService();
            else return instance;
        }
        #endregion

        #region Methods 
        public async Task<T> Get<T>(string url)
        {
            try
            {
                var response = await GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var message = JsonConvert.DeserializeObject<string>(result);
                    throw new ErrorResponseServerException(message);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var message = JsonConvert.DeserializeObject<string>(result);
                    throw new WarningResponseServerException(message);
                }
                else
                {
                    var data = JsonConvert.DeserializeObject<Response>(result);
                    var obj = JsonConvert.DeserializeObject<T>(data.Result.ToString());
                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Response> Create<T>(string url,T item)
        {
            try
            {
                var body = JsonConvert.SerializeObject(item);
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var message = JsonConvert.DeserializeObject<string>(result);
                    throw new ErrorResponseServerException(message);
                } 
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var message = JsonConvert.DeserializeObject<string>(result);
                    throw new WarningResponseServerException(message);
                }
                else
                {
                    var data = JsonConvert.DeserializeObject<Response>(result);
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Response> Update<T>(string url, T item, int id)
        {
            try
            {
                var body = JsonConvert.SerializeObject(item);
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await PutAsync($"{url}/{id}", content);
                var result = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var message = JsonConvert.DeserializeObject<string>(result);
                    throw new ErrorResponseServerException(message);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var message = JsonConvert.DeserializeObject<string>(result);
                    throw new WarningResponseServerException(message);
                }
                else
                {
                    var data = JsonConvert.DeserializeObject<Response>(result);
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Response> Delete<T>(string url, int id)
        {
            try
            {
                var response = await DeleteAsync($"{url}/{id}");
                var result = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(result);
                }
                 
                var list = JsonConvert.DeserializeObject<T>(result);
                return new Response
                {
                    Code = 0,
                    Message = "Ok",
                    Result = list
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
