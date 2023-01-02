namespace college.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intiallDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subject", "TeacherId", "dbo.Teacher");
            DropIndex("dbo.Subject", new[] { "TeacherId" });
            AddColumn("dbo.Teacher", "SubjectId", c => c.Int());
            CreateIndex("dbo.Teacher", "SubjectId");
            AddForeignKey("dbo.Teacher", "SubjectId", "dbo.Subject", "Id");
            DropColumn("dbo.Subject", "TeacherId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subject", "TeacherId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Teacher", "SubjectId", "dbo.Subject");
            DropIndex("dbo.Teacher", new[] { "SubjectId" });
            DropColumn("dbo.Teacher", "SubjectId");
            CreateIndex("dbo.Subject", "TeacherId");
            AddForeignKey("dbo.Subject", "TeacherId", "dbo.Teacher", "Id", cascadeDelete: true);
        }
    }
}
