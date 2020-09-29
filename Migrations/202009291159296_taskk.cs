namespace Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taskk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientPhoneNumbers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Email = c.String(),
                        address = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientPhoneNumbers", "ClientId", "dbo.Clients");
            DropIndex("dbo.ClientPhoneNumbers", new[] { "ClientId" });
            DropTable("dbo.Clients");
            DropTable("dbo.ClientPhoneNumbers");
        }
    }
}
