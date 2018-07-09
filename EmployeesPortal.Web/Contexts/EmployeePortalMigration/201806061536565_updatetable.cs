namespace EmployeesPortal.Web.Contexts.EmployeePortalMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostClicks", "clickby", c => c.String());
            AddColumn("dbo.PostClicks", "clickdate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostClicks", "clickdate");
            DropColumn("dbo.PostClicks", "clickby");
        }
    }
}
