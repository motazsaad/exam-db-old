namespace exam_db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editFile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Files", new[] { "Course_Id" });
            RenameColumn(table: "dbo.Files", name: "Course_Id", newName: "CourseId");
            AlterColumn("dbo.Files", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Files", "CourseId");
            AddForeignKey("dbo.Files", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "CourseId", "dbo.Courses");
            DropIndex("dbo.Files", new[] { "CourseId" });
            AlterColumn("dbo.Files", "CourseId", c => c.Int());
            RenameColumn(table: "dbo.Files", name: "CourseId", newName: "Course_Id");
            CreateIndex("dbo.Files", "Course_Id");
            AddForeignKey("dbo.Files", "Course_Id", "dbo.Courses", "Id");
        }
    }
}
