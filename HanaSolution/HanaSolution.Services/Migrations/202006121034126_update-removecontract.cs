namespace HanaSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateremovecontract : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Contracts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Code = c.String(),
                        FileScan = c.String(),
                        Status = c.Int(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
