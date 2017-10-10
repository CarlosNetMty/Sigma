using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Delta.Core.Observables
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Change : Entity
    {
        readonly internal DateTime dateTime;
        readonly internal string container;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        internal Change(string container)
        {
            this.dateTime = DateTime.UtcNow;
            this.container = container;
        }
        public abstract ChangeType Type { get; }
        public DateTime DateTime { get => dateTime; }
        public virtual string Comments { get; set; }
        [NotMapped] public object User { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public enum ChangeType
    {
        /// <summary>
        /// 
        /// </summary>
        Comment,
        /// <summary>
        /// 
        /// </summary>
        Property,
        /// <summary>
        /// 
        /// </summary>
        Collection
    }
}
