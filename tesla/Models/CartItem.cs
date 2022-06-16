using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tesla.Models
{
    public class CartItem
    {
        public Car Car { get; set; }
        public int Quantity { get; set; }
        public CartItem(Car car, int quanity)
        {
            Car = car;
            Quantity = quanity;
        }
    }
}