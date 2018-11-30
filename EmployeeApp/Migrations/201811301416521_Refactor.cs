namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shifts", "ShiftType_Id", "dbo.ShiftTypes");
            DropIndex("dbo.Shifts", new[] { "ShiftType_Id" });
            DropColumn("dbo.Shifts", "ShiftTypeId");
            RenameColumn(table: "dbo.Shifts", name: "ShiftType_Id", newName: "ShiftTypeId");
            AlterColumn("dbo.Shifts", "ShiftTypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Shifts", "ShiftTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Shifts", "ShiftTypeId");
            AddForeignKey("dbo.Shifts", "ShiftTypeId", "dbo.ShiftTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shifts", "ShiftTypeId", "dbo.ShiftTypes");
            DropIndex("dbo.Shifts", new[] { "ShiftTypeId" });
            AlterColumn("dbo.Shifts", "ShiftTypeId", c => c.Byte());
            AlterColumn("dbo.Shifts", "ShiftTypeId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Shifts", name: "ShiftTypeId", newName: "ShiftType_Id");
            AddColumn("dbo.Shifts", "ShiftTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shifts", "ShiftType_Id");
            AddForeignKey("dbo.Shifts", "ShiftType_Id", "dbo.ShiftTypes", "Id");
        }
    }
}
