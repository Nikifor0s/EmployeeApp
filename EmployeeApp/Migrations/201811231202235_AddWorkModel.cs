namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorkModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false),
                        ShiftId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeID, t.ShiftId })
                .ForeignKey("dbo.Shifts", t => t.ShiftId)
                .ForeignKey("dbo.Employees", t => t.EmployeeID)
                .Index(t => t.EmployeeID)
                .Index(t => t.ShiftId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Works", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Works", "ShiftId", "dbo.Shifts");
            DropIndex("dbo.Works", new[] { "ShiftId" });
            DropIndex("dbo.Works", new[] { "EmployeeID" });
            DropTable("dbo.Works");
        }
    }
}
