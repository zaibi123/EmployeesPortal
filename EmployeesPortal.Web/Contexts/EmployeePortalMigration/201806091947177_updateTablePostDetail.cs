namespace EmployeesPortal.Web.Contexts.EmployeePortalMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTablePostDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Users", "Address", c => c.String());
            AddColumn("dbo.Users", "City", c => c.String(maxLength: 100));
            AddColumn("dbo.Users", "StateId", c => c.Long());
            AddColumn("dbo.Users", "CountryId", c => c.Long());
            AddColumn("dbo.Users", "Zip", c => c.String(maxLength: 20));
            AddColumn("dbo.Users", "Phone", c => c.String(maxLength: 20));
            AddColumn("dbo.Users", "Mobile", c => c.String(maxLength: 20));
            AddColumn("dbo.Users", "ProfileImage", c => c.String(maxLength: 255));
            AddColumn("dbo.Users", "isactive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "isactive");
            DropColumn("dbo.Users", "ProfileImage");
            DropColumn("dbo.Users", "Mobile");
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.Users", "Zip");
            DropColumn("dbo.Users", "CountryId");
            DropColumn("dbo.Users", "StateId");
            DropColumn("dbo.Users", "City");
            DropColumn("dbo.Users", "Address");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
        }
    }
}
