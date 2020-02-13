namespace WebATM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckingAccountApplicationIdREquired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Checking_Accounts", "Application", "dbo.AspNetUsers");
            DropIndex("dbo.Checking_Accounts", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Checking_Accounts", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Checking_Accounts", "ApplicationUserId");
            AddForeignKey("dbo.Checking_Accounts", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checking_Accounts", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Checking_Accounts", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Checking_Accounts", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Checking_Accounts", "ApplicationUserId");
            AddForeignKey("dbo.Checking_Accounts", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
