namespace college.Database.Migrations
{
    using System;
    using System.Data;
    using System.Data.Entity.Migrations;
    
    public partial class EditStudentTableAddRegistrationNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "RegistrationNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "RegistrationNumber");
        }
    }
}
