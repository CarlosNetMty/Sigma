using Delta.Core.Observables.Collections;
using System.Collections.Specialized;

namespace Delta.Core.Observables
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CollectionChange : Change
    {
        /// <summary>
        /// 
        /// </summary>
        readonly ObservableCollectionChangedEventArgs content;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        internal CollectionChange(ObservableCollectionChangedEventArgs content) : base(string.Empty)
        {
            this.content = content;
        }
        /// <summary>
        /// 
        /// </summary>
        public NotifyCollectionChangedAction Action { get => content.Action; }
        /// <summary>
        /// 
        /// </summary>
        public override ChangeType Type => ChangeType.Collection;
    }
}
