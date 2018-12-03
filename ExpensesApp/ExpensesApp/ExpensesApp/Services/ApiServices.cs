﻿using ExpensesApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpensesApp.Services
{
    class ApiServices : HttpClient
    {
        private static readonly ApiServices instance = new ApiServices();
        static ApiServices() { }

        private ApiServices() : base()
        {
            Timeout = TimeSpan.FromMilliseconds(15000);
            MaxResponseContentBufferSize = 256000;
            BaseAddress = new Uri("http://192.168.15.8:26716");
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static ApiServices GetInstance()
        {
            if (instance == null) return new ApiServices();
            else return instance;
        }

        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Please turn on your internet settings."
                };
            }

            var isReachable = await CrossConnectivity.Current.IsReachable("motzcod.es");
            //if (!isReachable)
            //{
            //    return new Response
            //    {
            //        IsSuccess = false,
            //        Message = "check you internet connection."
            //    };
            //}

            return new Response
            {
                IsSuccess = true,
                Message = "Ok"
            };
        }

        public async Task<Response> GetList<T>(string url)
        {
            try
            {
                var response = await GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<T>(result);
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Result = responseData
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = responseData
                };
            }
            catch (OperationCanceledException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> GetItem<T>(string url)
        {
            try
            {
                var response = await GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Result = default(T)
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<T>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> PostItem<T>(string url,T item)
        {
            try
            {
                var body = JsonConvert.SerializeObject(item);
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Result = default(T)
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<T>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> PutItem<T>(string url, T item, int id)
        {
            try
            {
                var body = JsonConvert.SerializeObject(item);
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await PutAsync($"{url}/{id}", content);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Result = default(T)
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<T>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> DeleteItem<T>(string url, int id)
        {
            try
            {
                var response = await DeleteAsync($"{url}/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Result = default(T)
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<T>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

 
    }
}