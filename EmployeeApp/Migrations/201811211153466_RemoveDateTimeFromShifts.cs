namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDateTimeFromShifts : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Shifts", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shifts", "DateTime", c => c.DateTime());
        }
    }
}
