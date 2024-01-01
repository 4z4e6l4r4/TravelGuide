using SeyahatRehberi.Entity.Abstratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeyahatRehberi.Models
{
    public class BlogCityRelations : CommonProperty
    {
        public int CityId { get; set; }

        public Cities City { get; set; }
        public int BlogId { get; set; }

        public BlogPosts BlogPost { get; set; }
    }
}