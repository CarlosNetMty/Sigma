using Delta.Core.Observables.Notifications;

namespace Delta.Core.Observables
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class PropertyValueChange<T> : Change
    {
        readonly T currentValue;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        /// <param name="currentValue"></param>
        internal PropertyValueChange(string container, T currentValue) : base(container)
        {
            this.currentValue = currentValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        internal PropertyValueChange(ObservablePropertyValueChangedEventArgs content) :
            base(content?.PropertyName)
        {
            this.currentValue = (T)content?.Value;
        }
        public T CurrentValue { get => currentValue; }
        public string PropertyName { get => base.container; }
        public override ChangeType Type => ChangeType.Property;
    }
}
