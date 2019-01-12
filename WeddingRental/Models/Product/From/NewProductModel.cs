using Core.Enums;

namespace WeddingRental.Models.Product.From
{
    public class NewProductModel
    {
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public Color ProductColor { get; set; }
        public ProductType Type { get; set; }
    }
}