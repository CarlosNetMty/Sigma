using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sigma.Core.Model.Products.Characteristics
{
    public class SelectionProductCharacteristic : ProductCharacteristic
    {
        [Required] public SelectionProductCharacteristicType Type { get; set; }
        public IEnumerable<string> Options { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public enum SelectionProductCharacteristicType
        {
            SingleSelection, MultiSelection
        }
    }
}
