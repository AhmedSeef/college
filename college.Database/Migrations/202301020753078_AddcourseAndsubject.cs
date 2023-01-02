namespace college.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcourseAndsubject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subject", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Course", "Course_Id", "dbo.Course");
            DropIndex("dbo.Subject", new[] { "CourseId" });
            DropIndex("dbo.Course", new[] { "Course_Id" });
            DropTable("dbo.Subject");
            DropTable("dbo.Course");
        }
    }
}
