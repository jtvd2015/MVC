using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerProject.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [StringLength(80, ErrorMessage = "Max Length of Description field is 80 characters.")]
        public string Name { get; set; }

        public decimal Sales { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }

        public Customer()
        {
        }
    }
}