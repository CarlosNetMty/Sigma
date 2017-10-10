using Delta.Core.Observables.Notifications;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Delta.Core.Observables.Collections
{
    public interface INotifyObservableCollectionChanged : INotifyPropertyChanged
    {
        event ObservableCollectionChangedEventHandler ObservableCollectionChanged;
    }
    public delegate void ObservableCollectionChangedEventHandler(ObservableEntity sender, ObservableCollectionChangedEventArgs args);
    public class ObservableCollectionChangedEventArgs
    {
        readonly NotifyCollectionChangedEventArgs content;
        public ObservableCollectionChangedEventArgs(NotifyCollectionChangedEventArgs args)
        {
            this.content = args;
        }
        public bool HasValue { get => content != null; }
        public NotifyCollectionChangedAction Action { get => content.Action; }
    }
}
