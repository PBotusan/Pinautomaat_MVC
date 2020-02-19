namespace WebATM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionsUitbreiden3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "Omschrijving", c => c.String());
            AlterColumn("dbo.Transactions", "Plaats", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "Plaats", c => c.String(nullable: false));
            AlterColumn("dbo.Transactions", "Omschrijving", c => c.String(nullable: false));
        }
    }
}
