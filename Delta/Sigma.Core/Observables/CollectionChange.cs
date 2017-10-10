using Sigma.Core.Observables.Collections;
using System.Collections.Specialized;

namespace Sigma.Core.Observables
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CollectionChange : Change
    {
        readonly ObservableCollectionChangedEventArgs content;
        internal CollectionChange(ObservableCollectionChangedEventArgs content) : base(string.Empty)
        {
            this.content = content;
        }
        public NotifyCollectionChangedAction Action { get => content.Action; }
        public override ChangeType Type => ChangeType.Collection;
    }
}
