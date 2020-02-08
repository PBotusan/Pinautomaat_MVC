namespace WebATM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accountnumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AccountNummer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AccountNummer");
        }
    }
}
