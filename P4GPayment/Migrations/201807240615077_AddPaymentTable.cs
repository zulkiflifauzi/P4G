namespace P4GPayment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaymentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        Evidence = c.Binary(),
                        PayeeId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.PayeeId, cascadeDelete: true)
                .Index(t => t.PayeeId)
                .Index(t => t.AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payment", "PayeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Payment", "AddressId", "dbo.Address");
            DropIndex("dbo.Payment", new[] { "AddressId" });
            DropIndex("dbo.Payment", new[] { "PayeeId" });
            DropTable("dbo.Payment");
        }
    }
}
