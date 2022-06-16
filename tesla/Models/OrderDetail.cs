using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tesla.Models
{
    public class OrderDetail
    {

        [Key, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("Order")]
        public int order_id { get; set; }
        [ForeignKey("Car")]
        public int car_id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        public virtual Car Car { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}