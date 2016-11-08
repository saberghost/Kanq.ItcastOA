namespace Kanq.ItcastOA.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInfo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInfo", "UName", c => c.String(maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInfo", "UName", c => c.String(maxLength: 32));
        }
    }
}
