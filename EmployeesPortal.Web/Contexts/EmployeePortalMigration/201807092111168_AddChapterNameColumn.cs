namespace EmployeesPortal.Web.Contexts.EmployeePortalMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChapterNameColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "chaptername", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "chaptername");
        }
    }
}
