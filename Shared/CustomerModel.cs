using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared
{
  public  class CustomerModel
    {
        public int Id { get; set; }
        //[Remote("ValidateCountry", "Validator",ErrorMessage = "Please enter a valid country.")]
        //[Remote("IsAlreadySigned", "Values", HttpMethod = "POST", ErrorMessage = "Name already exists in database.")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public int Cnic { get; set; }
        public int CusInfoId { get; set; }
    }
}
