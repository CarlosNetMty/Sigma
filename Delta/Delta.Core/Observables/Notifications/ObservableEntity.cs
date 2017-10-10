using Delta.Core.Observables.Collections;
using System.ComponentModel;

namespace Delta.Core.Observables.Notifications
{
    public abstract class ObservableEntity : 
        Entity,
        INotifyPropertyChanging, 
        INotifyPropertyChanged,
        INotifyObservablePropertyValueChanged,
        INotifyObservableCollectionChanged
    {
        readonly IChangeset changes;
        public IChangeset Changes { get => changes; }
        public ObservableEntity()
        {
            changes = new Changeset<ObservableEntity>(this);
        }
        /// <summary>
        /// INotifyPropertyChanging.PropertyChanging
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;
        /// <summary>
        /// INotifyPropertyChanged.PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// INotifyObservablePropertyValueChanged.ObservablePropertyValueChanged
        /// </summary>
        public event ObservablePropertyValueChangedEventHandler ObservablePropertyValueChanged;
        /// <summary>
        /// INotifyObservableCollectionChanged.ObservableCollectionChanged
        /// </summary>
        public event ObservableCollectionChangedEventHandler ObservableCollectionChanged;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e">PropertyChangingEventArgs</param>
        internal virtual void OnPropertyChanging(PropertyChangingEventArgs e) => PropertyChanging?.Invoke(this, e);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e">PropertyChangedEventArgs</param>
        internal virtual void OnPropertyChanged(PropertyChangedEventArgs e) => PropertyChanged?.Invoke(this, e);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e">ObservableCollectionChangedEventArgs</param>
        internal virtual void OnObservableCollectionChanged(ObservableCollectionChangedEventArgs e) => ObservableCollectionChanged?.Invoke(this, e);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e">ObservablePropertyValueChangedEventArgs</param>
        internal virtual void OnObservablePropertyValueChanged(ObservablePropertyValueChangedEventArgs e) => ObservablePropertyValueChanged?.Invoke(this, e);
    }
}
