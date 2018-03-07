using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerProject.Models
{
    public class OrdersForCustomer
    {
        public Customer Customer { get; set; }
        public List<Orders> Orders { get; set; }

        public OrdersForCustomer()
        {
        }
    }
}