using Delta.Model.Products;
using Delta.Model.Products.Characteristics;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Delta.Model
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
