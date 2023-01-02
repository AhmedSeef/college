namespace college.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditCourseMistake : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Course", "Course_Id", "dbo.Course");
            DropIndex("dbo.Course", new[] { "Course_Id" });
            DropColumn("dbo.Course", "Course_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Course", "Course_Id", c => c.Int());
            CreateIndex("dbo.Course", "Course_Id");
            AddForeignKey("dbo.Course", "Course_Id", "dbo.Course", "Id");
        }
    }
}
