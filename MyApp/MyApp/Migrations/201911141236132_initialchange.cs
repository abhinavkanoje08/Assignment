namespace MyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialchange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientAddresses",
                c => new
                    {
                        ClientAddressId = c.Int(nullable: false, identity: true),
                        Cid = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ClientAddressId)
                .ForeignKey("dbo.Clients", t => t.Cid, cascadeDelete: true)
                .Index(t => t.Cid);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Cid = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Dob = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Cid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientAddresses", "Cid", "dbo.Clients");
            DropIndex("dbo.ClientAddresses", new[] { "Cid" });
            DropTable("dbo.Clients");
            DropTable("dbo.ClientAddresses");
        }
    }
}
