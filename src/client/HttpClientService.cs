using Newtonsoft.Json;
using server.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public class HttpClientService
    {
        static public HttpClient _client = new HttpClient();

        public HttpClientService()
        {
            _client.BaseAddress = new Uri("https://localhost:5001");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }


        public async Task GetDateRangeAsync(DateTime dateBefore, DateTime dateAfter)
        {
            var uri = "api/dates/range";
            var requestBody = JsonConvert.SerializeObject(new ViewDateModel
            {
                DateBefore = dateBefore,
                DateAfter = dateAfter
            });
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var dates = JsonConvert.DeserializeObject<ViewDateModel[]>(result);
                PrintDates(dates);
            }
            else
            {
                Console.WriteLine(response.StatusCode);
            }
        }

        private void PrintDates(ViewDateModel[] dates)
        {
            if (dates.Length == 0)
            {
                Console.WriteLine("The list is empty");
            }
            for (int i = 0; i < dates.Length; i++)
            {
                var before = (DateTime)dates[i].DateBefore;
                var after = (DateTime)dates[i].DateAfter;
                var test = before.Date;

                Console.WriteLine($"{test} \t\t {after.Date}");
            }
        }

        public async Task AddDateRangeAsync(DateTime dateBefore, DateTime dateAfter)
        {
            var uri = "api/dates";
            var requestBody = JsonConvert.SerializeObject(new ViewDateModel
            {
                DateBefore = dateBefore,
                DateAfter = dateAfter
            });
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();
        }
    }
}
