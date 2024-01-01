using SeyahatRehberi.Entity.Abstratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeyahatRehberi.Models
{
    public class Cities : CommonProperty
    {
        private List<BlogCityRelations> BlogCityRelation { get; set; }

    }
}