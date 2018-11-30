namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAnswerModel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Answers");
            AddPrimaryKey("dbo.Answers", new[] { "QuestionID", "PerformanceID" });
            DropColumn("dbo.Answers", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "ID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Answers");
            AddPrimaryKey("dbo.Answers", "ID");
        }
    }
}
