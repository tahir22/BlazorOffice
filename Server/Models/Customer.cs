using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Server.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //[Column("FirstName")]
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public int Cnic { get; set; }
        public int CusInfoId { get; set; }
        public Customerinformation Customerinformation { get; set; }
    }
}
