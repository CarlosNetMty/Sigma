namespace Delta.Core.Observables
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CommentChange : Change
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="comment"></param>
        public CommentChange(string comment) : base(comment) { }
        /// <summary>
        /// 
        /// </summary>
        public override ChangeType Type => ChangeType.Comment;
    }
}
