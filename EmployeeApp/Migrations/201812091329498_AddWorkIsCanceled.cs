namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorkIsCanceled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Works", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Works", "IsCanceled");
        }
    }
}
