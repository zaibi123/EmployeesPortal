namespace EmployeesPortal.Web.Contexts.EmployeePortalMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        comment = c.String(),
                        postid = c.Long(nullable: false),
                        commentby = c.String(),
                        commentDate = c.DateTime(nullable: false),
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
            DropForeignKey("dbo.Comments", "postid", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "postid" });
            DropTable("dbo.Comments");
        }
    }
}
