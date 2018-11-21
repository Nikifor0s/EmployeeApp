namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReafactorShiftAssign : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ShiftAssigns");
            AddColumn("dbo.ShiftAssigns", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ShiftAssigns", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ShiftAssigns");
            DropColumn("dbo.ShiftAssigns", "Id");
            AddPrimaryKey("dbo.ShiftAssigns", new[] { "EmployeeId", "ShiftId" });
        }
    }
}
