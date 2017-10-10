namespace Sigma.Core.Data
{
    /// <summary>
    /// Defines an entity that uses logic deletion.
    /// </summary>
    public interface IActivableEntity
    {
        bool IsActive { get; set; }
    }
}