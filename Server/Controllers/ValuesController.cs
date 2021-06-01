using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Server.Models;

namespace Test.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {


        TestDbContext dbContext;
        public ValuesController(TestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            try
            {
                //List<Customer> accidentsList = new List<Customer>();


                //var     accidentsList =   (from a in dbContext.Customers
                //                           select new Customer()
                //                           {
                //                               Id = a.Id,
                //                               Email = a.Email,
                //                               Name = a.Name,
                //                               MobileNo = a.MobileNo,

                //                           }).ToList();

                var accidentsList =  dbContext.Customers.ToList();


                return Ok(accidentsList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(Customer cus)
        {
            try
            {


                dbContext.Customers.Add(cus);
              await  dbContext.SaveChangesAsync();


                return Ok("Data successfully save");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
