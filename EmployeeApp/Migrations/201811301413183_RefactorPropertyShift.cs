namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorPropertyShift : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Shifts", name: "DayShift_Id", newName: "ShiftType_Id");
            RenameIndex(table: "dbo.Shifts", name: "IX_DayShift_Id", newName: "IX_ShiftType_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Shifts", name: "IX_ShiftType_Id", newName: "IX_DayShift_Id");
            RenameColumn(table: "dbo.Shifts", name: "ShiftType_Id", newName: "DayShift_Id");
        }
    }
}
