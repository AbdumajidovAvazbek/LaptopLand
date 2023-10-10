using LaptopLand.Domain.Commons;

namespace LaptopLand.Domain.Entities
{
    public class Product : Audiotable
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        public long CategoryId {  get; set; }
        public Category Category { get; set; }
    }
}
