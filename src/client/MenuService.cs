using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public class MenuService
    {
        private HttpClientService _clientService = new HttpClientService();
        public MenuService()
        {
        }

        public void ShowMenu()
        {
            string chooseItem = "Please, choose one of the menu item below:";
            string addItem = "1. Add date range.";
            string showItem = "2. Show me date range.";
            string exitItem = "3. Exit.";
            List<string> items = new List<string> { chooseItem, addItem, showItem, exitItem };
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(items[i]);
            }
        }


        private int GetKey()
        {
            int key;
            if (!int.TryParse(Console.ReadLine(), out key))
            {
                ShowMenu();
            }
            return key;
        }


        private DateTime GetDate(string dateType, string format = "yyyy/mm/dd")
        {
            string dateItem = $"Please enter {dateType}, format - {format}";

            Console.WriteLine(dateItem);
            string retryItem = $"You entered incorrect date. Please, try again. {dateItem}";
            while (true)
            {
                DateTime date;
                if (!DateTime.TryParse(Console.ReadLine(), out date))
                {
                    Console.WriteLine(retryItem);
                }
                return date;
            }
        }


        public async void ExecuteMethodAsync()
        {
            try
            {
                int key = GetKey();
                switch (key)
                {
                    case 1:
                        {
                            string dateBeforeType = "dateBefore";
                            var dateBefore = GetDate(dateBeforeType);

                            string dateAfterType = "dateAfter";
                            var dateAfter = GetDate(dateAfterType);
                            await _clientService.AddDateRangeAsync(dateBefore, dateAfter);
                            break;
                        }
                    case 2:
                        {
                            string dateBeforeType = "dateBefore";
                            var dateBefore = GetDate(dateBeforeType);

                            string dateAfterType = "dateAfter";
                            var dateAfter = GetDate(dateAfterType);
                            await _clientService.GetDateRangeAsync(dateBefore, dateAfter);
                            break;
                        }
                    case 3:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
