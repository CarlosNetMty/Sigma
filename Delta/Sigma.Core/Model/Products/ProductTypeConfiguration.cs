using Sigma.Core.Model.Products;
using Sigma.Core.Model.Products.Characteristics;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sigma.Core.Model.Products
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductTypeConfiguration
    {
        [Required, Key] public ProductType Type { get; set; }
        IEnumerable<ProductCharacteristic> Characteristics { get; set; }
    }
}
