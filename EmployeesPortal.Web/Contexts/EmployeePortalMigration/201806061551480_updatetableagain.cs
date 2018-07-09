namespace EmployeesPortal.Web.Contexts.EmployeePortalMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetableagain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostClicks", "postid", "dbo.Posts");
            DropIndex("dbo.PostClicks", new[] { "postid" });
            CreateTable(
                "dbo.PostClickCounts",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        postid = c.Long(nullable: false),
                        postclickby = c.String(),
                        postclickdate = c.String(),
                        createdonutc = c.DateTime(nullable: false),
                        updatedonutc = c.DateTime(),
                        ipused = c.String(maxLength: 20),
                        userid = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Posts", t => t.postid)
                .Index(t => t.postid);
            
            DropTable("dbo.PostClicks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PostClicks",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        postid = c.Long(nullable: false),
                        clickby = c.String(),
                        clickdate = c.String(),
                        createdonutc = c.DateTime(nullable: false),
                        updatedonutc = c.DateTime(),
                        ipused = c.String(maxLength: 20),
                        userid = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.PostClickCounts", "postid", "dbo.Posts");
            DropIndex("dbo.PostClickCounts", new[] { "postid" });
            DropTable("dbo.PostClickCounts");
            CreateIndex("dbo.PostClicks", "postid");
            AddForeignKey("dbo.PostClicks", "postid", "dbo.Posts", "id");
        }
    }
}
