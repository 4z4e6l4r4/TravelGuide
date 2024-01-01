using SeyahatRehberi.Entity.Abstratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeyahatRehberi.Models
{
    public class BlogPosts : CommonProperty
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }

        //Bu kısma bir dön
        public int UserId { get; set; }
        public Users User { get; set; }

        private List<BlogCityRelations> BlogCityRelation { get; set; }
        public List<BlogComments> BlogComments { get; set; }
        public List<BlogLikes> BlogLikes { get; set; }


    }
}