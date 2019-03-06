using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task GetAndPrintDates()
        {
            HttpResponseMessage response = await client.GetAsync(new Uri("https://localhost:5001/api/dates"));
            if (response.IsSuccessStatusCode)
            {
                var strings = await response.Content.ReadAsStringAsync();
                Console.WriteLine(strings);
            }
            else
            {
                Console.WriteLine(response.StatusCode);
            }
        }
        static async Task RunAsync()
        {
            try
            {
                client.BaseAddress = new Uri("https://localhost:5001");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                );
                await GetAndPrintDates();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
