namespace Manager.Core.Domain.Entities
{
    public class Factor_Store
    {
        public int Factor_StoreId { get; set; }
        public Store Store { set; get; }
        public Factor Factor { get; set; }
    }

}
