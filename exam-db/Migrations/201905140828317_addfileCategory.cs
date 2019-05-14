namespace exam_db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfileCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Files", "Category");
        }
    }
}
