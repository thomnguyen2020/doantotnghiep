namespace HanaSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateproduct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "IntendTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "IntendTime", c => c.Int(nullable: false));
        }
    }
}
