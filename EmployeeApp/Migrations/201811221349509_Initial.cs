namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactDetails",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        MobilePhone = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonalDetails",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        CurrentFamilyStatus = c.Int(nullable: false),
                        NumberOfChildren = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Sex = c.Int(nullable: false),
                        SSN = c.String(),
                        IdentityCard = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayShift = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shifts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ContactDetails", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.PersonalDetails", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Shifts", new[] { "EmployeeId" });
            DropIndex("dbo.PersonalDetails", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "RoleId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.ContactDetails", new[] { "EmployeeId" });
            DropTable("dbo.Shifts");
            DropTable("dbo.Roles");
            DropTable("dbo.PersonalDetails");
            DropTable("dbo.Departments");
            DropTable("dbo.Employees");
            DropTable("dbo.ContactDetails");
        }
    }
}
