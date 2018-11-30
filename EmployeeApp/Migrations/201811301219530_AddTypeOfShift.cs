namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeOfShift : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShiftTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Shifts", "ShiftTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Shifts", "DayShift_Id", c => c.Byte());
            CreateIndex("dbo.Shifts", "DayShift_Id");
            AddForeignKey("dbo.Shifts", "DayShift_Id", "dbo.ShiftTypes", "Id");
            DropColumn("dbo.Shifts", "DayShift");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shifts", "DayShift", c => c.Int(nullable: false));
            DropForeignKey("dbo.Shifts", "DayShift_Id", "dbo.ShiftTypes");
            DropIndex("dbo.Shifts", new[] { "DayShift_Id" });
            DropColumn("dbo.Shifts", "DayShift_Id");
            DropColumn("dbo.Shifts", "ShiftTypeId");
            DropTable("dbo.ShiftTypes");
        }
    }
}
