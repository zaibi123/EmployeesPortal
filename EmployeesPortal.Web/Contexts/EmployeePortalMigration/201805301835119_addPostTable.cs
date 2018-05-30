namespace EmployeesPortal.Web.Contexts.EmployeePortalMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPostTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        title = c.String(),
                        chapter_no = c.Int(nullable: false),
                        searchingwords = c.String(),
                        Description = c.String(),
                        isactive = c.Boolean(nullable: false),
                        departmentid = c.Long(nullable: false),
                        postcategoryid = c.Long(nullable: false),
                        createdonutc = c.DateTime(nullable: false),
                        updatedonutc = c.DateTime(),
                        ipused = c.String(maxLength: 20),
                        userid = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Departments", t => t.departmentid)
                .ForeignKey("dbo.PostCategories", t => t.postcategoryid)
                .Index(t => t.departmentid)
                .Index(t => t.postcategoryid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "postcategoryid", "dbo.PostCategories");
            DropForeignKey("dbo.Posts", "departmentid", "dbo.Departments");
            DropIndex("dbo.Posts", new[] { "postcategoryid" });
            DropIndex("dbo.Posts", new[] { "departmentid" });
            DropTable("dbo.Posts");
        }
    }
}
