namespace WebATM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Spaarrekeninguser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "User_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "User_Id");
        }
    }
}
