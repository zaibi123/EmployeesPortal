namespace EmployeesPortal.Web.Contexts.EmployeePortalMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewsFeedTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsFeeds",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        departmentid = c.Long(nullable: false),
                        title = c.String(),
                        description = c.String(),
                        isactive = c.Boolean(nullable: false),
                        createdonutc = c.DateTime(nullable: false),
                        updatedonutc = c.DateTime(),
                        ipused = c.String(maxLength: 20),
                        userid = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Departments", t => t.departmentid)
                .Index(t => t.departmentid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsFeeds", "departmentid", "dbo.Departments");
            DropIndex("dbo.NewsFeeds", new[] { "departmentid" });
            DropTable("dbo.NewsFeeds");
        }
    }
}
