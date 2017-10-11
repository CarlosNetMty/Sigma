using Sigma.Core.Data;
using Sigma.Core.Observables;
using Sigma.Core.Observables.Notifications;
using System.ComponentModel.DataAnnotations;

namespace Sigma.Core.Data
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class NamedEntity : IEntity, IActivableEntity
    {
        [MaxLength(10)] public virtual string Code { get; set; }
        [MaxLength(50)] public virtual string Name { get; set; }
        [MaxLength(100)] public virtual string Description { get; set; }
        public virtual bool IsActive { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public abstract class ObservableNamedEntity : ObservableActivableEntity
    {
        string code;
        [Required] public string Code { get => code; set => this.HandleProperty(value, out code); }

        string name;
        [Required] public string Name { get => name; set => this.HandleProperty(value, out name); }

        string description;
        public string Description { get => description; set => this.HandleProperty(value, out description); }
    }
}
