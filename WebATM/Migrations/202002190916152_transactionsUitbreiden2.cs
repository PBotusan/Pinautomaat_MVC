namespace WebATM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionsUitbreiden2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Plaats", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Plaats");
        }
    }
}
