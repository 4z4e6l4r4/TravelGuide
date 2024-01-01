using SeyahatRehberi.Entity.Abstratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeyahatRehberi.Models
{
    public class Roles : CommonProperty
    {
        public List<Users> Users { get; set; }
    }
}