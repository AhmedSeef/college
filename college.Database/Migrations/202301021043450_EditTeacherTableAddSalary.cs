namespace college.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTeacherTableAddSalary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teacher", "Salary", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teacher", "Salary");
        }
    }
}
