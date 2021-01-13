namespace DS.Common
{
    public class Post
    {
        public virtual Blog Blog { get; set; }
        public int BlogId { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; }
    }
}