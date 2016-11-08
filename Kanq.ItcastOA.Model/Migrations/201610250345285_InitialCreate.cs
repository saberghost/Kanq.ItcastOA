namespace Kanq.ItcastOA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubTime = c.DateTime(nullable: false),
                        DelFlag = c.Short(nullable: false),
                        ModifiedOn = c.String(nullable: false),
                        Remark = c.String(maxLength: 256),
                        Url = c.String(nullable: false, maxLength: 512),
                        HttpMethod = c.String(nullable: false, maxLength: 32),
                        ActionMethodName = c.String(maxLength: 32),
                        ControllerName = c.String(maxLength: 128),
                        ActionInfoName = c.String(nullable: false, maxLength: 32),
                        Sort = c.String(),
                        ActionTypeEnum = c.Short(nullable: false),
                        MenuIcon = c.String(maxLength: 512, unicode: false),
                        IconWidth = c.Int(nullable: false),
                        IconHeight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.R_UserInfo_ActionInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserInfoID = c.Int(nullable: false),
                        ActionInfoID = c.Int(nullable: false),
                        IsPass = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserInfo", t => t.UserInfoID)
                .ForeignKey("dbo.ActionInfo", t => t.ActionInfoID)
                .Index(t => t.UserInfoID)
                .Index(t => t.ActionInfoID);
            
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UName = c.String(maxLength: 32),
                        UPwd = c.String(nullable: false, maxLength: 16),
                        SubTime = c.DateTime(nullable: false),
                        DelFlag = c.Short(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Remark = c.String(maxLength: 256),
                        Sort = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Author = c.String(nullable: false, maxLength: 200),
                        PublisherId = c.Int(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                        ISBN = c.String(nullable: false, maxLength: 50),
                        WordsCount = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 19, scale: 4),
                        ContentDescription = c.String(),
                        AurhorDescription = c.String(),
                        EditorComment = c.String(),
                        TOC = c.String(),
                        CategoryId = c.Int(),
                        Clicks = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DepName = c.String(nullable: false, maxLength: 32),
                        ParentId = c.Int(nullable: false),
                        TreePath = c.String(nullable: false, maxLength: 128),
                        Level = c.Int(nullable: false),
                        IsLeaf = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KeyWordsRank",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        KeyWords = c.String(maxLength: 255),
                        SearchCount = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 32),
                        DelFlag = c.Short(nullable: false),
                        SubTime = c.DateTime(nullable: false),
                        Remark = c.String(maxLength: 256),
                        ModifiedOn = c.DateTime(nullable: false),
                        Sort = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SearchDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        KeyWords = c.String(maxLength: 255),
                        SearchDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.R_UserInfo_ActionInfo", "ActionInfoID", "dbo.ActionInfo");
            DropForeignKey("dbo.R_UserInfo_ActionInfo", "UserInfoID", "dbo.UserInfo");
            DropIndex("dbo.R_UserInfo_ActionInfo", new[] { "ActionInfoID" });
            DropIndex("dbo.R_UserInfo_ActionInfo", new[] { "UserInfoID" });
            DropTable("dbo.SearchDetails");
            DropTable("dbo.RoleInfo");
            DropTable("dbo.KeyWordsRank");
            DropTable("dbo.Department");
            DropTable("dbo.Books");
            DropTable("dbo.UserInfo");
            DropTable("dbo.R_UserInfo_ActionInfo");
            DropTable("dbo.ActionInfo");
        }
    }
}
