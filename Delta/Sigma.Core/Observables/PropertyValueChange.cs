using Sigma.Core.Observables.Notifications;

namespace Sigma.Core.Observables
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class PropertyValueChange<T> : Change
    {
        readonly T currentValue;
        internal PropertyValueChange(string container, T currentValue) : base(container)
        {
            this.currentValue = currentValue;
        }
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
