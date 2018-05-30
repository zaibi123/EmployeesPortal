namespace EmployeesPortal.Web.Contexts.EmployeePortalMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPostDetailTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostDetails",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        departmentid = c.Long(nullable: false),
                        postcategoryid = c.Long(nullable: false),
                        postid = c.Long(nullable: false),
                        employeeid = c.String(),
                        is_read = c.Boolean(nullable: false),
                        is_understand = c.Boolean(nullable: false),
                        first_visit_date = c.DateTime(nullable: false),
                        last_visit_date = c.DateTime(nullable: false),
                        createdonutc = c.DateTime(nullable: false),
                        updatedonutc = c.DateTime(),
                        ipused = c.String(maxLength: 20),
                        userid = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Departments", t => t.departmentid)
                .ForeignKey("dbo.Posts", t => t.postid)
                .ForeignKey("dbo.PostCategories", t => t.postcategoryid)
                .Index(t => t.departmentid)
                .Index(t => t.postcategoryid)
                .Index(t => t.postid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostDetails", "postcategoryid", "dbo.PostCategories");
            DropForeignKey("dbo.PostDetails", "postid", "dbo.Posts");
            DropForeignKey("dbo.PostDetails", "departmentid", "dbo.Departments");
            DropIndex("dbo.PostDetails", new[] { "postid" });
            DropIndex("dbo.PostDetails", new[] { "postcategoryid" });
            DropIndex("dbo.PostDetails", new[] { "departmentid" });
            DropTable("dbo.PostDetails");
        }
    }
}
