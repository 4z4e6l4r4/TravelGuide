using SeyahatRehberi.Entity.Abstratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeyahatRehberi.Models
{
    public class BlogLikes : CommonProperty
    {
        public int UserId { get; set; }
        public Users User { get; set; }
        public int BlogId { get; set; }
        public BlogPosts BlogPost { get; set; }
    }
}