using System.Collections.Generic;
using System.Text;

namespace Manager.Core.Domain.Entities
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public int StoreId { get; set; }
        public Store  Store { get; set; }
        public int FactorId { get; set; }
        public Factor factor { get; set; }
    }


}
