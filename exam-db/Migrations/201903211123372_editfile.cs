namespace exam_db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colleges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        University_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Universities", t => t.University_Id)
                .Index(t => t.University_Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        collgeId = c.Int(nullable: false),
                        college_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colleges", t => t.college_Id)
                .Index(t => t.college_Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        departmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.departmentId, cascadeDelete: true)
                .Index(t => t.departmentId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        path = c.String(),
                        type = c.Int(nullable: false),
                        size = c.Long(nullable: false),
                        like_number = c.Int(nullable: false),
                        dislike_number = c.Int(nullable: false),
                        Download_number = c.Int(nullable: false),
                        view_numbre = c.Int(nullable: false),
                        year = c.Int(nullable: false),
                        semester = c.Int(nullable: false),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        country = c.String(),
                        logo_path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Colleges", "University_Id", "dbo.Universities");
            DropForeignKey("dbo.Files", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "departmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "college_Id", "dbo.Colleges");
            DropIndex("dbo.Files", new[] { "Course_Id" });
            DropIndex("dbo.Courses", new[] { "departmentId" });
            DropIndex("dbo.Departments", new[] { "college_Id" });
            DropIndex("dbo.Colleges", new[] { "University_Id" });
            DropTable("dbo.Universities");
            DropTable("dbo.Files");
            DropTable("dbo.Courses");
            DropTable("dbo.Departments");
            DropTable("dbo.Colleges");
        }
    }
}
