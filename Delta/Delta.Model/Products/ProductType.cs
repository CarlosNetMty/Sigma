using Delta.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Delta.Model.Products
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductType : NamedEntity, IContainerEntity
    {
        public IEnumerable<Product> Products { get; set; }
        [NotMapped] public bool IsUsed => Products.Any();
    }
}
