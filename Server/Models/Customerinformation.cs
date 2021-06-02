using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Server.Models
{
    public class Customerinformation
    {
        [Key]
        public int CusInfoId { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
         
        public ICollection<Customer> Customer { get; set; }
    }
}
