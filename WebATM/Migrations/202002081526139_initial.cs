namespace WebATM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Checking_Accounts", "AccountNummer", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Checking_Accounts", "AccountNummer", c => c.String(nullable: false));
        }
    }
}
