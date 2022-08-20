using System;

namespace Manager.Core.Domain.DTOs
{
    public class FactorDTO
    {
        public int FactorId { get; set; }
        public int ProductId { get; set; }
        public int Tedad { get; set; }
        public DateTime SellTime { get; set; }
        public string Costomer { get; set; }


    }
}
