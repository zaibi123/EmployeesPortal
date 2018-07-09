namespace EmployeesPortal.Web.Contexts.EmployeePortalMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class countrystateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        iso = c.String(maxLength: 2),
                        iso3 = c.String(maxLength: 3),
                        name = c.String(nullable: false, maxLength: 80),
                        nicename = c.String(nullable: false, maxLength: 80),
                        numcode = c.Short(),
                        phonecode = c.Short(),
                        createdonutc = c.DateTime(nullable: false),
                        updatedonutc = c.DateTime(),
                        ipused = c.String(maxLength: 20),
                        userid = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 40),
                        abbreviation = c.String(maxLength: 2),
                        countryid = c.Long(nullable: false),
                        createdonutc = c.DateTime(nullable: false),
                        updatedonutc = c.DateTime(),
                        ipused = c.String(maxLength: 20),
                        userid = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Countries", t => t.countryid)
                .Index(t => t.countryid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.States", "countryid", "dbo.Countries");
            DropIndex("dbo.States", new[] { "countryid" });
            DropTable("dbo.States");
            DropTable("dbo.Countries");
        }
    }
}
