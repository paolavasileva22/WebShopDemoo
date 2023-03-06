using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopDemo.Models.Order
{
    public class OrderIndexVM
    {
<<<<<<< HEAD
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public string OrderDate { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }

        public int ProductId { get; set; }

        public string Product { get; set; }

        public string Picture { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

=======
        public int Id { get; set; }
        public string OrderDate { get; set; }
        public string UserId { get; set; }
        public string User { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public string Picture { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
>>>>>>> ae7627cbbfd20722d2bcef569ae59baf0c0820e5
        public decimal TotalPrice { get; set; }
    }
}
