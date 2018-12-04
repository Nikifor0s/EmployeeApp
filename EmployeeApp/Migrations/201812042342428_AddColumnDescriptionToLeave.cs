namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnDescriptionToLeave : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leaves", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leaves", "Description");
        }
    }
}
