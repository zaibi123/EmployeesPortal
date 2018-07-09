namespace EmployeesPortal.Web.Contexts.EmployeePortalMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postclicktable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostClicks",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        postid = c.Long(nullable: false),
                        createdonutc = c.DateTime(nullable: false),
                        updatedonutc = c.DateTime(),
                        ipused = c.String(maxLength: 20),
                        userid = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Posts", t => t.postid)
                .Index(t => t.postid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostClicks", "postid", "dbo.Posts");
            DropIndex("dbo.PostClicks", new[] { "postid" });
            DropTable("dbo.PostClicks");
        }
    }
}
