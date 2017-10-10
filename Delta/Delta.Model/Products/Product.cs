using Delta.Core;
using System.ComponentModel.DataAnnotations;

namespace Delta.Model.Products
{
    /// <summary>
    /// 
    /// </summary>
    public class Product : Entity
    {
        [MaxLength(50)] public virtual string Name { get; set; }
        [MaxLength(100)] public virtual string Description { get; set; }
        [Required] public ProductType Type { get; set; }
        public ProductCategory Category { get; set; }
        public ProductFamily Family { get; set; }
    }
}
