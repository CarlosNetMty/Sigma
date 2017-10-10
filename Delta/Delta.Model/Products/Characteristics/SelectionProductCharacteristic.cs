using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Delta.Model.Products.Characteristics
{
    public class SelectionProductCharacteristic : ProductCharacteristic
    {
        /// <summary>
        /// 
        /// </summary>
        [Required] public SelectionProductCharacteristicType Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
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
