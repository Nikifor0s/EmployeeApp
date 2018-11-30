namespace EmployeeApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateShiftType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ShiftTypes (Id, Name) VALUES (1, 'Morning')");
            Sql("INSERT INTO ShiftTypes (Id, Name) VALUES (2, 'Evening')");
            Sql("INSERT INTO ShiftTypes (Id, Name) VALUES (3, 'Night')");
        }

        public override void Down()
        {
            Sql("DELETE FROM ShiftTypes WHERE Id IN(1, 2, 3)");
        }
    }
}