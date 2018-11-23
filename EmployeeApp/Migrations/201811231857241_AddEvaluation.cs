namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEvaluation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                        PerformanceID = c.Int(nullable: false),
                        Text = c.String(),
                        QuestionAnswer = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Performances", t => t.PerformanceID, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID)
                .Index(t => t.PerformanceID);
            
            CreateTable(
                "dbo.Performances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        EvaluationID = c.Int(nullable: false),
                        FormID = c.Int(nullable: false),
                        OveralRating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateEvaluated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Evaluations", t => t.EvaluationID, cascadeDelete: true)
                .ForeignKey("dbo.Forms", t => t.FormID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.EvaluationID)
                .Index(t => t.FormID);
            
            CreateTable(
                "dbo.Evaluations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartEvaluationDate = c.DateTime(nullable: false),
                        EndEvaluationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Theme = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.QuestionForms",
                c => new
                    {
                        Question_ID = c.Int(nullable: false),
                        Form_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_ID, t.Form_ID })
                .ForeignKey("dbo.Questions", t => t.Question_ID, cascadeDelete: true)
                .ForeignKey("dbo.Forms", t => t.Form_ID, cascadeDelete: true)
                .Index(t => t.Question_ID)
                .Index(t => t.Form_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionForms", "Form_ID", "dbo.Forms");
            DropForeignKey("dbo.QuestionForms", "Question_ID", "dbo.Questions");
            DropForeignKey("dbo.Answers", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.Performances", "FormID", "dbo.Forms");
            DropForeignKey("dbo.Performances", "EvaluationID", "dbo.Evaluations");
            DropForeignKey("dbo.Performances", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Answers", "PerformanceID", "dbo.Performances");
            DropIndex("dbo.QuestionForms", new[] { "Form_ID" });
            DropIndex("dbo.QuestionForms", new[] { "Question_ID" });
            DropIndex("dbo.Performances", new[] { "FormID" });
            DropIndex("dbo.Performances", new[] { "EvaluationID" });
            DropIndex("dbo.Performances", new[] { "EmployeeID" });
            DropIndex("dbo.Answers", new[] { "PerformanceID" });
            DropIndex("dbo.Answers", new[] { "QuestionID" });
            DropTable("dbo.QuestionForms");
            DropTable("dbo.Questions");
            DropTable("dbo.Forms");
            DropTable("dbo.Evaluations");
            DropTable("dbo.Performances");
            DropTable("dbo.Answers");
        }
    }
}
