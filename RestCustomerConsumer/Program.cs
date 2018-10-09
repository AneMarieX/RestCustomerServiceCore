using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestCustomerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintCustomers();
            Console.ReadKey();
        }

        public static async Task<IList<Customer>> GetCustomersAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync("http://localhost:44343/api/Customers");
                IList<Customer> cList = JsonConvert.DeserializeObject<IList<Customer>>(content);
                return cList;
            }


        }

        public static async void PrintCustomers()
        {

            IList<Customer> names = await GetCustomersAsync();

            foreach (Customer c in names)
            {
                Console.WriteLine(  $"name {c.FirstName}");
            }

           
        }

    }


}

