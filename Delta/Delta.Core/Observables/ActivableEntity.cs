using Delta.Core.Observables.Notifications;
using System.ComponentModel.DataAnnotations;

namespace Delta.Core.Observables
{
    /// <summary>
    /// 
    /// </summary>
    public interface IActivableEntity
    {
        bool IsActive { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public abstract class ActivableEntity :
        ObservableEntity,
        IActivableEntity
    {
        bool isActive;
        [Required] public virtual bool IsActive { get => isActive; set => this.HandleProperty(value, out isActive); }
    }
}
