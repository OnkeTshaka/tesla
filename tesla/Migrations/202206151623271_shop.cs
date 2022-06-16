namespace tesla.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        order_id = c.Int(nullable: false),
                        car_id = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cars", t => t.car_id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.order_id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.order_id)
                .Index(t => t.car_id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerPhone = c.String(),
                        CustomerEmail = c.String(),
                        CustomerAddress = c.String(),
                        Refcode = c.String(),
                        From = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        PaymentType = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderDetails", "order_id", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "car_id", "dbo.Cars");
            DropIndex("dbo.OrderDetails", new[] { "User_Id" });
            DropIndex("dbo.OrderDetails", new[] { "car_id" });
            DropIndex("dbo.OrderDetails", new[] { "order_id" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
        }
    }
}
