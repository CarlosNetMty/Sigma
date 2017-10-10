using System;

namespace Sigma.Core.Data
{
    /// <summary>
    /// Defines an entity that implements simple audit data.
    /// </summary>
    public interface IAuditableEntity
    {
        DateTime Created { get; set; }
        string CreatedBy { get; set; }
        DateTime Modified { get; set; }
        string ModifiedBy { get; set; }
    }
}
