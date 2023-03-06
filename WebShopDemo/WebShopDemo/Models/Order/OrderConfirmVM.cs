using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopDemo.Models.Order
{
    public class OrderConfirmVM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
<<<<<<< HEAD

        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }

        public string User { get; set; }
        [Required]

        public int ProductId { get; set; }

        public string ProductName { get; set; }

=======
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public string User { get; set; }
        [Required]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
>>>>>>> ae7627cbbfd20722d2bcef569ae59baf0c0820e5
        public string Picture { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Quantity")]
<<<<<<< HEAD

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalPrice { get; set; }

=======
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
>>>>>>> ae7627cbbfd20722d2bcef569ae59baf0c0820e5
    }
}
