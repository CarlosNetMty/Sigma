using Delta.Core;

namespace Delta.Model.Products.Characteristics
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ProductCharacteristic : NamedEntity
    {
        public ProductType ProductType { get; set; }
    }
}
