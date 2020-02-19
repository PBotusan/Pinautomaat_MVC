namespace WebATM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionsUitbreiden : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Hoeveelheid", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transactions", "Omschrijving", c => c.String(nullable: false));
            AddColumn("dbo.Transactions", "Datum", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transactions", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Transactions", "Datum");
            DropColumn("dbo.Transactions", "Omschrijving");
            DropColumn("dbo.Transactions", "Hoeveelheid");
        }
    }
}
