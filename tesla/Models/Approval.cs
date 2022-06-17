using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tesla.Models
{
    public class Approval
    {
        [Key, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CommentId { get; set; } = Guid.NewGuid();
        public DateTime? ThisDateTime { get; set; }
        public int car_id { get; set; }
        public int? Rating { get; set; }
    }
}