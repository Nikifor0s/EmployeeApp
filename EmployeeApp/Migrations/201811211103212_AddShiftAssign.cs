namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShiftAssign : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "ShiftId", "dbo.Shifts");
            DropForeignKey("dbo.Accounts", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Accounts", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "ShiftId" });
            CreateTable(
                "dbo.ShiftAssigns",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        ShiftId = c.Int(nullable: false),
                        Datetime = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.ShiftId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Shifts", t => t.ShiftId)
                .Index(t => t.EmployeeId)
                .Index(t => t.ShiftId);
            
            DropColumn("dbo.Employees", "ShiftId");
            DropTable("dbo.Accounts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            AddColumn("dbo.Employees", "ShiftId", c => c.Int());
            DropForeignKey("dbo.ShiftAssigns", "ShiftId", "dbo.Shifts");
            DropForeignKey("dbo.ShiftAssigns", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.ShiftAssigns", new[] { "ShiftId" });
            DropIndex("dbo.ShiftAssigns", new[] { "EmployeeId" });
            DropTable("dbo.ShiftAssigns");
            CreateIndex("dbo.Employees", "ShiftId");
            CreateIndex("dbo.Accounts", "EmployeeId");
            AddForeignKey("dbo.Accounts", "EmployeeId", "dbo.Employees", "Id");
            AddForeignKey("dbo.Employees", "ShiftId", "dbo.Shifts", "Id");
        }
    }
}
