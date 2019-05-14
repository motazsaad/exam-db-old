namespace exam_db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Departments", "college_Id", "dbo.Colleges");
            DropIndex("dbo.Departments", new[] { "college_Id" });
            AlterColumn("dbo.Departments", "college_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Departments", "college_Id");
            AddForeignKey("dbo.Departments", "college_Id", "dbo.Colleges", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "college_Id", "dbo.Colleges");
            DropIndex("dbo.Departments", new[] { "college_Id" });
            AlterColumn("dbo.Departments", "college_Id", c => c.Int());
            CreateIndex("dbo.Departments", "college_Id");
            AddForeignKey("dbo.Departments", "college_Id", "dbo.Colleges", "Id");
        }
    }
}
