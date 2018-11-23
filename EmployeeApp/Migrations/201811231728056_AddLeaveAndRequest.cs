namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLeaveAndRequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false),
                        LeaveID = c.Int(nullable: false),
                        DateRequestedLeave = c.DateTime(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeID, t.LeaveID })
                .ForeignKey("dbo.Leaves", t => t.LeaveID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID)
                .Index(t => t.EmployeeID)
                .Index(t => t.LeaveID);
            
            CreateTable(
                "dbo.Leaves",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartDateOfLeave = c.DateTime(nullable: false),
                        EndDateOfLeave = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Requests", "LeaveID", "dbo.Leaves");
            DropIndex("dbo.Requests", new[] { "LeaveID" });
            DropIndex("dbo.Requests", new[] { "EmployeeID" });
            DropTable("dbo.Leaves");
            DropTable("dbo.Requests");
        }
    }
}
