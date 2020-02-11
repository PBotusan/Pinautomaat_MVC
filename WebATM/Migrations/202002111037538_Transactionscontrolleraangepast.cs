namespace WebATM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transactionscontrolleraangepast : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Transactions", new[] { "User_Id" });
            CreateIndex("dbo.Transactions", "CheckingAccountId");
            AddForeignKey("dbo.Transactions", "CheckingAccountId", "dbo.Checking_Accounts", "Id", cascadeDelete: true);
            DropColumn("dbo.Transactions", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "User_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Transactions", "CheckingAccountId", "dbo.Checking_Accounts");
            DropIndex("dbo.Transactions", new[] { "CheckingAccountId" });
            CreateIndex("dbo.Transactions", "User_Id");
            AddForeignKey("dbo.Transactions", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
