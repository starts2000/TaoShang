using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using Microsoft.Owin.Hosting;
using Starts2000.TaobaoPlatform.Manager.Models;

namespace Starts2000.TaobaoPlatform.Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = ConfigurationManager.AppSettings["BaseAddress"];

            // Start OWIN host 
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Manager Server Start at {0}.", baseAddress);
            WebApp.Start<Startup>(url: baseAddress);
            //using(WebApp.Start<Startup>(url: baseAddress))
            //{
            //    // Create HttpCient and make a request to api/values 
            //    HttpClient client = new HttpClient();
            //    client.BaseAddress = new Uri(baseAddress);

            //    var response = client.GetAsync("/user/list/1/5").Result;

            //    var data = response.Content.ReadAsAsync<Tuple<int, IList<User>>>();
            //    data.Wait();
            //    Console.WriteLine(data.Result.Item1.ToString());
            //}

            Console.ReadLine(); 
        }
    }
}
