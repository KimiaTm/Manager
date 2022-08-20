using System;
using System.Collections.Generic;

namespace Manager.Core.Domain.Entities
{
    public class Factor
    {
        public int FactorId { get; set; }

        public int Tedad { get; set; }
        public DateTime SellTime { get; set; }
        public string Costomer { get; set; }
        public int ProductId { get; set; }
        public List<Products> products { get; set; }
        public int Factor_StoreId { get; set; }
        public List<Factor_Store> factor_Stores { get; set; }
    }

}
