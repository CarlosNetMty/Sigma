using Delta.Core.Observables;
using Delta.Core.Observables.Notifications;
using System.ComponentModel.DataAnnotations;

namespace Delta.Core
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class NamedEntity : Entity, IActivableEntity
    {
        [MaxLength(10)] public virtual string Code { get; set; }
        [MaxLength(50)] public virtual string Name { get; set; }
        [MaxLength(100)] public virtual string Description { get; set; }
        public virtual bool IsActive { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public abstract class ObservableNamedEntity : ActivableEntity
    {
        string code;
        [Required] public string Code { get => code; set => this.HandleProperty(value, out code); }

        string name;
        [Required] public string Name { get => name; set => this.HandleProperty(value, out name); }

        string description;
        public string Description { get => description; set => this.HandleProperty(value, out description); }
    }
}
