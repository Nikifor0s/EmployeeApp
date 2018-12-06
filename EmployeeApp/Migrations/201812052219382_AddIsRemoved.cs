namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsRemoved : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IsRemoved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "IsRemoved");
        }
    }
}
