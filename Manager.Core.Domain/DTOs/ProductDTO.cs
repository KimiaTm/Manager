using System.Collections.Generic;
using System.Text;

namespace Manager.Core.Domain.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
    }
}
