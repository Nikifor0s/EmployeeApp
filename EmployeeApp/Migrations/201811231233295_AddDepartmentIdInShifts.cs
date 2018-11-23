namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentIdInShifts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shifts", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shifts", "DepartmentId");
            AddForeignKey("dbo.Shifts", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shifts", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Shifts", new[] { "DepartmentId" });
            DropColumn("dbo.Shifts", "DepartmentId");
        }
    }
}
