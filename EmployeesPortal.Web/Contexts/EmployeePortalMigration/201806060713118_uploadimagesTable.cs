namespace EmployeesPortal.Web.Contexts.EmployeePortalMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uploadimagesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UploadImages",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        images = c.String(),
                        createdonutc = c.DateTime(nullable: false),
                        updatedonutc = c.DateTime(),
                        ipused = c.String(maxLength: 20),
                        userid = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UploadImages");
        }
    }
}
