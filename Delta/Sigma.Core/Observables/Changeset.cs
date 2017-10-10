using Sigma.Core.Data;
using Sigma.Core.Observables.Collections;
using Sigma.Core.Observables.Notifications;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigma.Core.Observables
{
    /// <summary>
    /// 
    /// </summary>
    public interface IChangeset : IEnumerable<Change>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        void Append(ObservablePropertyValueChangedEventArgs e);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        void Append(ObservableCollectionChangedEventArgs e);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="comments"></param>
        void Append(string comments);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Changeset<T> : IChangeset, IEntity
    {
        [Key] public Guid Id { get; set; }

        readonly T parent;
        readonly ICollection<Change> contents;
        public Changeset(T parent)
        {
            this.parent = parent;
            this.contents = new HashSet<Change>();
        }

        [NotMapped] public int Count => contents.Count;
        [NotMapped] public bool IsReadOnly => true;

        public IEnumerator<Change> GetEnumerator() => contents.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => contents.GetEnumerator();

        public void Append(ObservablePropertyValueChangedEventArgs e) => this.contents.Add(new PropertyValueChange<object>(e));
        public void Append(ObservableCollectionChangedEventArgs e) => this.contents.Add(new CollectionChange(e));
        public void Append(string comments) => this.contents.Add(new CommentChange(comments));
    }
}
