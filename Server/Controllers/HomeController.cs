using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Server.Models;

namespace Test.Server.Controllers
{
    public class HomeController : Controller
    {
        TestDbContext dbContext;
        public HomeController(TestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public bool IsUserAvailable(string name)
        {
            // Assume these details coming from database  

            var RegEmailId = (from u in dbContext.Customers
                              where u.Name.ToUpper() == name.ToUpper()
                              select new { name }).FirstOrDefault();

            bool status;
            if (RegEmailId != null)
            {
                //Already registered  
                status = false;
            }
            else
            {
                //Available to use  
                status = true;
            }


            return status;
        }
        public bool IsUserAvailableemail(string email)
        {
            // Assume these details coming from database  



            bool status = true;



            return status;
        }
    }
}
