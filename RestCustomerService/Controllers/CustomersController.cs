using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestCustomerService.Model;


namespace RestCustomerService.Controllers
{

    
 [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    { 
     public static List<Customer> CList { get => cList; set => cList = value; }
    
        private static List<Customer> cList = new List<Customer>()
        {
            new Customer(01,"Anders","Holbæk",2014),
            new Customer(02,"Line","Bjørk",2002),
            new Customer(03,"Thomas","Petersen",2014),


        };



        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return cList;
        }

        // GET: api/Customers/5
        [HttpGet("{id}", Name = "Get")]
        public IEnumerable<Customer> Get(int id)
        {
            yield return cList[id];
        }

      

        // POST: api/Customers
        [HttpPost]
        public void Post([FromBody] string value)
        {
            cList.Add((new Customer(04, "Bob", "Robbinson", 2016)));
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cList.RemoveAt(02);
        }
    }
}
