using System;

namespace Sigma.Core.Model.Products.Characteristics
{
    /// <summary>
    /// Numeric range product characteristic e.g. weight
    /// </summary>
    /// <typeparam name="T">Numeric type</typeparam>
    public sealed class RangeProductCharacteristic<T>
                : ProductCharacteristic
        where T : struct,
                    IComparable,
                    IComparable<T>,
                    IConvertible,
                    IEquatable<T>,
                    IFormattable
    {
        public T MinValue { get; set; }
        public T MaxValue { get; set; }
    }
}
