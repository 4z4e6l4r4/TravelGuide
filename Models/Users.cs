using SeyahatRehberi.Entity.Abstratcs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeyahatRehberi.Models
{
    public class Users : CommonProperty
    {
        [MinLength(8)]
        public string Password { get; set; }
        public string Email { get; set; }
        public int SignUpDate { get; set; }

        public List<BlogPosts> BlogPost { get; set; }
        public int RoleId { get; set; }
        public Roles Role { get; set; }

        public List<BlogComments> BlogComments { get; set; }
        public List<BlogLikes> BlogLikes { get; set; }


    }
}