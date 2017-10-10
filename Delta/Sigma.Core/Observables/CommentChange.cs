namespace Sigma.Core.Observables
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CommentChange : Change
    {
        public CommentChange(string comment) : base(comment) { }
        /// <summary>
        /// 
        /// </summary>
        public override ChangeType Type => ChangeType.Comment;
    }
}
