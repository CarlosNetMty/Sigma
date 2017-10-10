using System.ComponentModel;

namespace Sigma.Core.Observables.Notifications
{
    /// <summary>
    /// 
    /// </summary>
    public interface INotifyObservablePropertyValueChanging : INotifyPropertyChanging
    {
        event ObservablePropertyValueChangingEventHandler ObservablePropertyValueChanging;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void ObservablePropertyValueChangingEventHandler(ObservableEntity sender, ObservablePropertyValueChangingEventArgs args);
    /// <summary>
    /// 
    /// </summary>
    public class ObservablePropertyValueChangingEventArgs : PropertyChangingEventArgs
    {
        readonly object value;
        public object Value { get => value; }
        public ObservablePropertyValueChangingEventArgs(string propertyName, object propertyValue) : base(propertyName)
        {
            value = propertyValue;
        }
    }
}
