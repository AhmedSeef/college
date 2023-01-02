namespace college.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EdittacheartableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Teachers", newName: "Teacher");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Teacher", newName: "Teachers");
        }
    }
}
