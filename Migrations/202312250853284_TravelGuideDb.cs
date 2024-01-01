namespace SeyahatRehberi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TravelGuideDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogPosts", "BlogPosts_Id", "dbo.BlogPosts");
            DropForeignKey("dbo.Cities", "Cities_Id", "dbo.Cities");
            DropIndex("dbo.BlogPosts", new[] { "BlogPosts_Id" });
            DropIndex("dbo.Cities", new[] { "Cities_Id" });
            DropColumn("dbo.BlogPosts", "BlogPosts_Id");
            DropColumn("dbo.Cities", "Cities_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cities", "Cities_Id", c => c.Int());
            AddColumn("dbo.BlogPosts", "BlogPosts_Id", c => c.Int());
            CreateIndex("dbo.Cities", "Cities_Id");
            CreateIndex("dbo.BlogPosts", "BlogPosts_Id");
            AddForeignKey("dbo.Cities", "Cities_Id", "dbo.Cities", "Id");
            AddForeignKey("dbo.BlogPosts", "BlogPosts_Id", "dbo.BlogPosts", "Id");
        }
    }
}
