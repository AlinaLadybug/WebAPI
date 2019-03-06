using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace client
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                MenuService menu = new MenuService();
                HttpClientService httpService = new HttpClientService();
                while (true)
                {
                    menu.ShowMenu();
                    menu.ExecuteMethodAsync();
                    Console.WriteLine("Just wait a second");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
            }
        }



    }
}
