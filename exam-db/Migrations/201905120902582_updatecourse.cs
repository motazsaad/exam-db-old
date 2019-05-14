namespace exam_db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "code");
        }
    }
}
