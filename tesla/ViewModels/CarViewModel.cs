using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tesla.Models;

namespace tesla.ViewModels
{
    public class CarViewModel
    {
        public IEnumerable<Car> Car { get; set; }
    }
}