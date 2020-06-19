namespace HanaSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignPositions",
                c => new
                    {
                        StaffID = c.Int(nullable: false),
                        PositionID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        Desc = c.String(),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.StaffID, t.PositionID, t.DepartmentID });
            
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Avatar = c.String(),
                        Desc = c.String(maxLength: 250),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BookingLogs",
                c => new
                    {
                        TransactionID = c.String(nullable: false, maxLength: 128),
                        Step = c.Int(nullable: false),
                        Name = c.String(),
                        Member = c.Int(nullable: false),
                        PostJson = c.String(),
                        PartnerResult = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.TransactionID, t.Step });
            
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
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        Desc = c.String(maxLength: 550),
                        Phone = c.String(maxLength: 50),
                        Mail = c.String(maxLength: 150),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Comment = c.String(maxLength: 550),
                        Member = c.Int(nullable: false),
                        Rate = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MemberLevels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Point = c.Double(nullable: false),
                        Rank = c.Int(nullable: false),
                        Name = c.String(maxLength: 250),
                        Desc = c.String(maxLength: 550),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MemberReceiptInfos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Member = c.Int(nullable: false),
                        Phone = c.String(maxLength: 250),
                        FullName = c.String(maxLength: 250),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        Address = c.String(maxLength: 350),
                        Phone = c.String(maxLength: 50),
                        Gender = c.Int(nullable: false),
                        Mail = c.String(maxLength: 150),
                        Account = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        DateJoin = c.DateTime(nullable: false),
                        Platform = c.String(),
                        BirthDay = c.DateTime(),
                        AccumulatedPoints = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        Avatar = c.String(),
                        Desc = c.String(maxLength: 350),
                        Content = c.String(),
                        ViewNumber = c.Int(nullable: false),
                        MetaTitle = c.String(maxLength: 60),
                        MetaDesc = c.String(maxLength: 160),
                        MetaKeyword = c.String(maxLength: 260),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 250),
                        Product = c.Long(nullable: false),
                        Price = c.Double(nullable: false),
                        Reduce = c.Double(nullable: false),
                        Qty = c.Int(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Code, t.Product });
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Code = c.String(maxLength: 250),
                        Date = c.DateTime(nullable: false),
                        TypePayment = c.Int(nullable: false),
                        StatusPayment = c.Int(nullable: false),
                        StatusOrder = c.Int(nullable: false),
                        Member = c.Int(nullable: false),
                        Receipt = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        Reduce = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        DateUpdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        Desc = c.String(maxLength: 550),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductCategorys",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        Desc = c.String(maxLength: 350),
                        Rank = c.Int(nullable: false),
                        Avatar = c.String(),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductFeedbacks",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Product = c.Long(nullable: false),
                        Rate = c.Int(nullable: false),
                        Comment = c.String(maxLength: 850),
                        Files = c.String(),
                        Member = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        Desc = c.String(maxLength: 350),
                        Content = c.String(),
                        Staff = c.Int(nullable: false),
                        Avatar = c.String(),
                        Category = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        IntendTime = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Code = c.String(maxLength: 6),
                        Title = c.String(maxLength: 250),
                        Avatar = c.String(),
                        Desc = c.String(maxLength: 350),
                        Content = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Limit = c.Int(nullable: false),
                        StartAge = c.Int(nullable: false),
                        EndAge = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        MemberLevel = c.Int(nullable: false),
                        MemberPoint = c.Double(nullable: false),
                        Type = c.String(),
                        Staff = c.Long(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        Address = c.String(maxLength: 350),
                        BirthDay = c.DateTime(),
                        Phone = c.String(maxLength: 50),
                        Gender = c.Int(nullable: false),
                        Mail = c.String(maxLength: 150),
                        Account = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Vouchers",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Code = c.String(),
                        Type = c.Int(nullable: false),
                        IsApplyOrder = c.Boolean(nullable: false),
                        Product = c.String(),
                        AmountReduced = c.Int(nullable: false),
                        PercentReduced = c.Double(nullable: false),
                        DateUsed = c.DateTime(),
                        IsUsed = c.Boolean(nullable: false),
                        Staff = c.Long(nullable: false),
                        Promotion = c.Long(nullable: false),
                        Receiver = c.Int(nullable: false),
                        IsReceiver = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vouchers");
            DropTable("dbo.Staffs");
            DropTable("dbo.Promotions");
            DropTable("dbo.Products");
            DropTable("dbo.ProductFeedbacks");
            DropTable("dbo.ProductCategorys");
            DropTable("dbo.Positions");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.News");
            DropTable("dbo.Members");
            DropTable("dbo.MemberReceiptInfos");
            DropTable("dbo.MemberLevels");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Departments");
            DropTable("dbo.Contracts");
            DropTable("dbo.BookingLogs");
            DropTable("dbo.Banners");
            DropTable("dbo.AssignPositions");
        }
    }
}
