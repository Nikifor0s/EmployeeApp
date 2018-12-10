namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipWorkProjects : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assignments", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Assignments", new[] { "EmployeeId" });
            DropPrimaryKey("dbo.Assignments");
            AddColumn("dbo.Assignments", "WorkId", c => c.Int(nullable: false));
            AddColumn("dbo.Assignments", "Work_EmployeeID", c => c.Int(nullable: false));
            AddColumn("dbo.Assignments", "Work_ShiftId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Assignments", new[] { "WorkId", "ProjectId" });
            CreateIndex("dbo.Assignments", new[] { "Work_EmployeeID", "Work_ShiftId" });
            AddForeignKey("dbo.Assignments", new[] { "Work_EmployeeID", "Work_ShiftId" }, "dbo.Works", new[] { "EmployeeID", "ShiftId" });
            DropColumn("dbo.Assignments", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assignments", "EmployeeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Assignments", new[] { "Work_EmployeeID", "Work_ShiftId" }, "dbo.Works");
            DropIndex("dbo.Assignments", new[] { "Work_EmployeeID", "Work_ShiftId" });
            DropPrimaryKey("dbo.Assignments");
            DropColumn("dbo.Assignments", "Work_ShiftId");
            DropColumn("dbo.Assignments", "Work_EmployeeID");
            DropColumn("dbo.Assignments", "WorkId");
            AddPrimaryKey("dbo.Assignments", new[] { "EmployeeId", "ProjectId" });
            CreateIndex("dbo.Assignments", "EmployeeId");
            AddForeignKey("dbo.Assignments", "EmployeeId", "dbo.Employees", "Id");
        }
    }
}
