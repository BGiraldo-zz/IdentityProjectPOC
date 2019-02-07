using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIdentity.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Display(Name = "Product Name")] // this is the name view by the user
        [StringLength(30, ErrorMessage = "The field {0} must be between {1} and {2}", MinimumLength = 3)]
        public string Name { get; set; }
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Please fill this field {0}")]
        public string Code { get; set; }
        public string Serial { get; set; }
    }
}
