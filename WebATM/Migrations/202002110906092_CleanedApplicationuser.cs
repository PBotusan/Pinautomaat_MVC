namespace WebATM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CleanedApplicationuser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "AccountNummer");
            DropColumn("dbo.AspNetUsers", "Voornaam");
            DropColumn("dbo.AspNetUsers", "Achternaam");
            DropColumn("dbo.AspNetUsers", "TelefoonNummer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "TelefoonNummer", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Achternaam", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Voornaam", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "AccountNummer", c => c.Int(nullable: false));
        }
    }
}
