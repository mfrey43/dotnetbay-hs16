using System;
using System.Data.Entity.SqlServer;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace DotNetBay.SelfHost
{
    class Program
    {
        // ROLA - This is a hack to ensure that Entity Framework SQL Provider is copied across to the output folder.
        // As it is installed in the GAC, Copy Local does not work. It is required for probing.
        // Fixed "Provider not loaded" error
        SqlProviderServices ensureDLLIsCopied = SqlProviderServices.Instance;

        static void Main(string[] args)
        {
            var binding = "http://localhost:8080/";

            WebApp.Start<Startup>(binding);

            Console.WriteLine($"Webserver is running on {binding}");
            Console.WriteLine("");

            // Create HttpCient and make a request to api/values 
            HttpClient client = new HttpClient();

            var response = client.GetAsync(binding + "api/status").Result;

            Console.WriteLine(response);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);


            Console.WriteLine("Press Enter to quit.");
            Console.ReadLine();
        }
    }
}
