using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tesla.Models
{
    public class Car
    {
        [Key, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string title { get; set; }

        public bool inStock { get; set; }

        public string description { get; set; }

        public string img { get; set; }

        public decimal price { get; set; }

        public string hightlights { get; set; }

        public int quanitity { get; set; }
    }
}