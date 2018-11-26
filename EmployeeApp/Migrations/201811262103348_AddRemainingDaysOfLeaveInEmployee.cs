namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRemainingDaysOfLeaveInEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "RemaingDaysOfLeave", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "RemaingDaysOfLeave");
        }
    }
}
