using Core.Enums;

namespace Services.Descriptors
{
    public class NewProductDescriptor
    {
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public Color ProductColor { get; set; }
        public ProductType Type { get; set; }
    }
}