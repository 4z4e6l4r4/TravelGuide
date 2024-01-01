using SeyahatRehberi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SeyahatRehberi.Entity
{
    public class DataContext : DbContext
    {
        public DataContext():base("DbConnection") { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<BlogPosts> BlogPosts { get; set; }
        public DbSet<BlogCityRelations> BlogCityRelations { get; set; }

        public System.Data.Entity.DbSet<SeyahatRehberi.Models.Roles> Roles { get; set; }
    }
}