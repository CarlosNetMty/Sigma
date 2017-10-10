using Sigma.Core.Data;
using Sigma.Core.Observables.Notifications;
using System.ComponentModel.DataAnnotations;

namespace Sigma.Core.Observables
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ObservableActivableEntity :
        ObservableEntity,
        IActivableEntity
    {
        bool isActive;
        [Required] public virtual bool IsActive { get => isActive; set => this.HandleProperty(value, out isActive); }
    }
}
