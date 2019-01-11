using Core.Enums;

namespace Data.Views
{
    public class ProductCatalogView
    {
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public int ProductId { get; set; }
        public Color ProductColor { get; set; }
        public ProductType Type { get; set; }
    }
}