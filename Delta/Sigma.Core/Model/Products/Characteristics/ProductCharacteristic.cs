using Sigma.Core;

namespace Sigma.Core.Model.Products.Characteristics
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ProductCharacteristic : NamedEntity
    {
        public ProductType ProductType { get; set; }
    }
}
