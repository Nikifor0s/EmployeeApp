namespace EmployeeApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateDomainModel : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Shifts( DayShift) VALUES ( 'Morning')");
            Sql("INSERT INTO Shifts( DayShift) VALUES ( 'Evening')");
            Sql("INSERT INTO Shifts( DayShift) VALUES ( 'Night')");

            Sql("INSERT INTO Departments( Name, Address) VALUES ( 'HR', 'Palaiologou 1')");
            Sql("INSERT INTO Departments( Name, Address) VALUES ( 'Sales', 'Spiridwn 3')");
            Sql("INSERT INTO Departments( Name, Address) VALUES ( 'Production', 'Panepistimiou 8')");

            Sql("INSERT INTO Roles( Name) VALUES ( 'Administrator')");
            Sql("INSERT INTO Roles( Name) VALUES ( 'Manager')");
            Sql("INSERT INTO Roles( Name) VALUES ( 'Worker')");
            Sql("INSERT INTO Roles( Name) VALUES ( 'Salesman')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Shifts WHERE DayShift IN ('Morning', 'Evening', 'Night')");
            Sql("DELETE FROM Departments WHERE Name IN ('HR', 'Sales', 'Production')");
            Sql("DELETE FROM Departments WHERE Address IN ('Palaiologou 1', 'Spiridwn 3', 'Panepistimiou 8')");
            Sql("DELETE FROM Roles WHERE Name IN ('Administrator', 'Manager', 'Worker', 'Salesman')");
        }
    }
}