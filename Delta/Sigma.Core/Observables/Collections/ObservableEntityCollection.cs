using Sigma.Core.Observables.Notifications;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Sigma.Core.Observables.Collections
{
    public sealed class ObservableEntityCollection<T> :
        ObservableCollection<T>,
        INotifyObservableCollectionChanged
    {
        readonly ObservableEntity parent;
        public ObservableEntityCollection(ObservableEntity parent)
        {
            this.parent = parent;
        }
        /// <summary>
        /// 
        /// </summary>
        public event ObservableCollectionChangedEventHandler ObservableCollectionChanged;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
            ObservableCollectionChanged?.Invoke(parent, new ObservableCollectionChangedEventArgs(e));
            this.parent.OnObservableCollectionChanged(new ObservableCollectionChangedEventArgs(e));
        }
    }
}
