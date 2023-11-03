using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    /// <summary>
    /// Temp Cart
    /// </summary>
    public class CartItem
    {

        public int Id { get; set; }
        public string? CageName { get; set; }
        public decimal DetailPrice { get; set; } 
        public int DetailQuantity { get; set; }
        public decimal TotalPrice { get; set; } 
        public int type { get; set; }
    }
}
