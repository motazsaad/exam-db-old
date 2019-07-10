namespace exam_db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix_user_bug : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "department_Id", "dbo.Departments");
            DropIndex("dbo.AspNetUsers", new[] { "department_Id" });
            RenameColumn(table: "dbo.AspNetUsers", name: "department_Id", newName: "departmentId");
            AlterColumn("dbo.AspNetUsers", "departmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "departmentId");
            AddForeignKey("dbo.AspNetUsers", "departmentId", "dbo.Departments", "Id", cascadeDelete: true);
            DropColumn("dbo.AspNetUsers", "depatrmantId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "depatrmantId", c => c.Int(nullable: false));
            DropForeignKey("dbo.AspNetUsers", "departmentId", "dbo.Departments");
            DropIndex("dbo.AspNetUsers", new[] { "departmentId" });
            AlterColumn("dbo.AspNetUsers", "departmentId", c => c.Int());
            RenameColumn(table: "dbo.AspNetUsers", name: "departmentId", newName: "department_Id");
            CreateIndex("dbo.AspNetUsers", "department_Id");
            AddForeignKey("dbo.AspNetUsers", "department_Id", "dbo.Departments", "Id");
        }
    }
}
