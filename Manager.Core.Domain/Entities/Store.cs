using System.Collections.Generic;

namespace Manager.Core.Domain.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Mojodi { get; set; }
        public int ProductId { get; set; }
        public List<Products> products { get; set; }
        public int Factor_StoreId { get; set; }
        public List<Factor_Store> factor_Stores { get; set; }
    }
}
