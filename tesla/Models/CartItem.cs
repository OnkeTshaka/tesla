using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tesla.Models
{
    public class CartItem
    {
        private List<CartItem> lineCollection = new List<CartItem>();

        public Car Car { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<CartItem> Lines
        {

            get { return lineCollection; }
        }
        public IEnumerable<CartItem> onke { get; set; }
       
        public decimal ComputeTotalValue()
        {

            return lineCollection.Sum(e => e.Car.price * e.Quantity);

        }
        public CartItem(Car car, int quanity)
        {
            Car = car;
            Quantity = quanity;
        }
    }
}