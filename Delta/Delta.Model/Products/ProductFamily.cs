using Delta.Core;
using System.Collections.Generic;

namespace Delta.Model.Products
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductFamily : NamedEntity
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
