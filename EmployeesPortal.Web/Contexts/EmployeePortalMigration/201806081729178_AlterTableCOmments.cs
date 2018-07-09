namespace EmployeesPortal.Web.Contexts.EmployeePortalMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableCOmments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "commentbyUserId", c => c.String());
            AddColumn("dbo.Comments", "commentbyUserName", c => c.String());
            DropColumn("dbo.Comments", "commentby");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "commentby", c => c.String());
            DropColumn("dbo.Comments", "commentbyUserName");
            DropColumn("dbo.Comments", "commentbyUserId");
        }
    }
}
