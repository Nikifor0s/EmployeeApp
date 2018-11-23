namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropEmpoyeePropertyFromShift : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shifts", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Shifts", new[] { "EmployeeId" });
            DropColumn("dbo.Shifts", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shifts", "EmployeeId", c => c.Int());
            CreateIndex("dbo.Shifts", "EmployeeId");
            AddForeignKey("dbo.Shifts", "EmployeeId", "dbo.Employees", "Id");
        }
    }
}
