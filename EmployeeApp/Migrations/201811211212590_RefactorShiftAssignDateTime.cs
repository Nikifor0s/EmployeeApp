namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorShiftAssignDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShiftAssigns", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShiftAssigns", "DateTime", c => c.DateTime());
        }
    }
}
