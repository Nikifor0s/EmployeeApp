namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorShiftAssigns : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ShiftAssigns");
            AddPrimaryKey("dbo.ShiftAssigns", new[] { "EmployeeId", "ShiftId" });
            DropColumn("dbo.ShiftAssigns", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShiftAssigns", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.ShiftAssigns");
            AddPrimaryKey("dbo.ShiftAssigns", "Id");
        }
    }
}
