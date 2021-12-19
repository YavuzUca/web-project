using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RAAST_web.App_Start
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        public static DateTime LastCall { get; set; }
        public static int Count = 0;
        public static void InitializeClient()
        {
            LastCall = DateTime.Now;

            ApiClient = new HttpClient();
            //ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/ld+json"));
            ApiClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue(
                    "Bearer", 
                    "b76e9869694eaac165d20107a705ff0bb329fdd6257b00c7d32cd5b0b8ed561a559ab50e328dff92d75e321a52fd015aaa0ee2c336953b57a300fbfa"
                    );
        }
    }
}