namespace college.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditStudenttableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Students", newName: "Student");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Student", newName: "Students");
        }
    }
}
