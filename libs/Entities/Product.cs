using Core.Base;
using Core.Enums;

namespace Entities
{
    public sealed class Product : BaseEntity
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public Color Color { get; set; }
    }
}