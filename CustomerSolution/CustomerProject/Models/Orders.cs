using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerProject.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [StringLength(80, ErrorMessage = "Max Length of Description field is 80 characters.")]
        public string Description { get; set; }

        public decimal Total { get; set; }
        public int CustomerId { get; set; }  //Foreign Key, real Db SQL connection
        public virtual Customer Customer { get; set; }  //virtual means that the Customer

        public Orders() //constructor
        {
        }

        public Orders(DateTime date, string description, decimal total, int customerId)  //this a constructor and it is creating an instance of a class.  when creating an instance of type Order, Order O = new Order(); (constructor is a method in the class that is called when initializing the type)
        {
            this.Id = 0;  //new instance of Customer Id
            this.Date = date;  //this is required when the property on the left of the = sign is a property of class, on the right is from the parameter list
            this.Description = description;
            this.Total = total;
            this.CustomerId = customerId;
        }
    }
}