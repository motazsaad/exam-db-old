namespace exam_db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix_department_model : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Departments", "college_Id1", "dbo.Colleges");
            DropIndex("dbo.Departments", new[] { "college_Id1" });
            RenameColumn(table: "dbo.Departments", name: "college_Id1", newName: "collegeId");
            AlterColumn("dbo.Departments", "collegeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Departments", "collegeId");
            AddForeignKey("dbo.Departments", "collegeId", "dbo.Colleges", "Id", cascadeDelete: true);
            DropColumn("dbo.Departments", "college_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "college_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Departments", "collegeId", "dbo.Colleges");
            DropIndex("dbo.Departments", new[] { "collegeId" });
            AlterColumn("dbo.Departments", "collegeId", c => c.Int());
            RenameColumn(table: "dbo.Departments", name: "collegeId", newName: "college_Id1");
            CreateIndex("dbo.Departments", "college_Id1");
            AddForeignKey("dbo.Departments", "college_Id1", "dbo.Colleges", "Id");
        }
    }
}
