using Sigma.Core.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Sigma.Core.Model.Products
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductCategory : NamedEntity, IContainerEntity
    {
        public IEnumerable<Product> Products { get; set; }
        [NotMapped] public bool IsUsed => Products != null && Products.Any();
    }
}
