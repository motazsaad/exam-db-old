namespace exam_db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editdept : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "collge_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Departments", "collgeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "collgeId", c => c.Int(nullable: false));
            DropColumn("dbo.Departments", "collge_Id");
        }
    }
}
