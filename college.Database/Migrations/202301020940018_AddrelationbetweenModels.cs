namespace college.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddrelationbetweenModels : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Teachers");
            CreateTable(
                "dbo.StudentSubjects",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        SubjecteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.SubjecteID })
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjecteID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.SubjecteID);
            
            AddColumn("dbo.Subject", "TeacherId", c => c.Int(nullable: false));
            AlterColumn("dbo.Teachers", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Teachers", "Id");
            CreateIndex("dbo.Teachers", "Id");
            AddForeignKey("dbo.Teachers", "Id", "dbo.Subject", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "Id", "dbo.Subject");
            DropForeignKey("dbo.StudentSubjects", "SubjecteID", "dbo.Subject");
            DropForeignKey("dbo.StudentSubjects", "StudentID", "dbo.Students");
            DropIndex("dbo.StudentSubjects", new[] { "SubjecteID" });
            DropIndex("dbo.StudentSubjects", new[] { "StudentID" });
            DropIndex("dbo.Teachers", new[] { "Id" });
            DropPrimaryKey("dbo.Teachers");
            AlterColumn("dbo.Teachers", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Subject", "TeacherId");
            DropTable("dbo.StudentSubjects");
            AddPrimaryKey("dbo.Teachers", "Id");
        }
    }
}
