using System.ComponentModel;

namespace Sigma.Core.Observables.Notifications
{
    /// <summary>
    /// 
    /// </summary>
    public interface INotifyObservablePropertyValueChanged : INotifyPropertyChanged
    {
        event ObservablePropertyValueChangedEventHandler ObservablePropertyValueChanged;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void ObservablePropertyValueChangedEventHandler(ObservableEntity sender, ObservablePropertyValueChangedEventArgs args);
    /// <summary>
    /// 
    /// </summary>
    public class ObservablePropertyValueChangedEventArgs : PropertyChangedEventArgs
    {
        readonly object value;
        public object Value { get => value; }
        public ObservablePropertyValueChangedEventArgs(string propertyName, object propertyValue) : base(propertyName)
        {
            value = propertyValue;
        }
    }
}
