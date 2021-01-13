using System;
using System.Collections.Generic;

namespace DS.Common
{
    public class Blog
    {
        public Blog()
        {
            Post = new HashSet<Post>();
        }
        public int BlogId { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public string Url { get; set; }
    }
}