using System;

namespace Delta.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuditableEntity
    {
        DateTime Created { get; set; }
        string CreatedBy { get; set; }
        DateTime Modified { get; set; }
        string ModifiedBy { get; set; }
    }
}
