using Sigma.Core;
using Sigma.Core.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Sigma.Core.Model.Products
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
