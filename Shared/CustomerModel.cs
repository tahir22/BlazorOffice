using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared
{
  public  class CustomerModel
    {
        public int Id { get; set; }
        //[Remote("ValidateCountry", "Validator",ErrorMessage = "Please enter a valid country.")]
        [Required]
        [Remote("IsUserAvailable", "Home",  ErrorMessage = "Name already exists in database.")]
        public string Name { get; set; }
        [Required]
        [Remote("IsUserAvailableemail", "Home")]
        public string Email { get; set; }
        [Required (ErrorMessage ="enter mobile number ")]
     
        public string MobileNo { get; set; }
        public int Cnic { get; set; }
        public int CusInfoId { get; set; }
    }
}
