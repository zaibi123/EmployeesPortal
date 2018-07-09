namespace EmployeesPortal.Web.Contexts.EmployeePortalMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altertabletest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostDetails", "isread", c => c.Boolean(nullable: false));
            AddColumn("dbo.PostDetails", "isunderstand", c => c.Boolean(nullable: false));
            AddColumn("dbo.PostDetails", "firstvisitdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PostDetails", "lastvisitdate", c => c.DateTime(nullable: false));
            DropColumn("dbo.PostDetails", "is_read");
            DropColumn("dbo.PostDetails", "is_understand");
            DropColumn("dbo.PostDetails", "first_visit_date");
            DropColumn("dbo.PostDetails", "last_visit_date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostDetails", "last_visit_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.PostDetails", "first_visit_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.PostDetails", "is_understand", c => c.Boolean(nullable: false));
            AddColumn("dbo.PostDetails", "is_read", c => c.Boolean(nullable: false));
            DropColumn("dbo.PostDetails", "lastvisitdate");
            DropColumn("dbo.PostDetails", "firstvisitdate");
            DropColumn("dbo.PostDetails", "isunderstand");
            DropColumn("dbo.PostDetails", "isread");
        }
    }
}
