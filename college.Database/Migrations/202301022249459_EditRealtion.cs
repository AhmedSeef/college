namespace college.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditRealtion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teacher", "SubjectId", "dbo.Subject");
            DropIndex("dbo.Teacher", new[] { "SubjectId" });
            AddColumn("dbo.Subject", "TeacherId", c => c.Int());
            CreateIndex("dbo.Subject", "TeacherId");
            AddForeignKey("dbo.Subject", "TeacherId", "dbo.Teacher", "Id");
            DropColumn("dbo.Teacher", "SubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teacher", "SubjectId", c => c.Int());
            DropForeignKey("dbo.Subject", "TeacherId", "dbo.Teacher");
            DropIndex("dbo.Subject", new[] { "TeacherId" });
            DropColumn("dbo.Subject", "TeacherId");
            CreateIndex("dbo.Teacher", "SubjectId");
            AddForeignKey("dbo.Teacher", "SubjectId", "dbo.Subject", "Id");
        }
    }
}
